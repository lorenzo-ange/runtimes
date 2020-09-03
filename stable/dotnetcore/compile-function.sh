#!/bin/bash

exit_on_error() {
    exit_code=$?
    last_command=$(fc -ln -1 | awk '{$1=$1};1')
    if [ $exit_code -ne 0 ]; then
        echo "\"${last_command}\" command failed with exit code ${exit_code}."
        exit $exit_code
    fi
}

# kubeless function directory
PROJECT_MOUNT=$1
echo Mount $PROJECT_MOUNT

# set project files variables
PACKAGES_DIR=$PROJECT_MOUNT/packages
USER_PROJ=$PROJECT_MOUNT/*proj

# compile
dotnet restore $USER_PROJ --packages $PACKAGES_DIR
exit_on_error
dotnet publish $USER_PROJ -o publish -c Release --no-restore
exit_on_error

# execute Entity Framework Core DB migrations (if any)
cd $PROJECT_MOUNT
if [ -d "Migrations" ] 
then
    echo "DB migrations execution started"
    echo "CONNECTION_STRING='$CONNECTION_STRING'"
    dotnet add package Microsoft.EntityFrameworkCore.Design -v $EF_CORE_VERSION
    exit_on_error
    dotnet ef database update
    exit_on_error
else
    echo "No DB migrations found"
fi