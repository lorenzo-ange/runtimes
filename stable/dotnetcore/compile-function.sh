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
