#!/bin/bash

# kubeless function directory
PROJECT_MOUNT=$1
echo Mount $PROJECT_MOUNT

# set project files variables
PACKAGES_DIR=$PROJECT_MOUNT/packages
USER_PROJ=$PROJECT_MOUNT/*proj

# compile
dotnet restore $USER_PROJ --packages $PACKAGES_DIR
dotnet publish $USER_PROJ -o publish -c Release --no-restore

# execute Entity Framework Core DB migrations (if any)
cd $PROJECT_MOUNT
if [ -d "Migrations" ] 
then
    echo "DB migrations execution started"
    echo "CONNECTION_STRING='$CONNECTION_STRING'"
    dotnet tool install --global dotnet-ef
    export PATH="$PATH:/root/.dotnet/tools"
    dotnet add package Microsoft.EntityFrameworkCore.Design -v 3.1.2
    if ! dotnet ef database update; then
        echo "DB migration failed"
        exit 1
    else
        echo "DB migrations execution ended"
    fi
else
    echo "No DB migrations found"
fi