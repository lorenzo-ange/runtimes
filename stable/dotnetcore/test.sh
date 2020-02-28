#!/bin/sh

#
#cp /kubeless/publish/project.dll /app
#dotnet --additional-deps /kubeless/publish/project.deps.json --additionalprobingpath /kubeless/packages /app/Kubeless.WebAPI.dll


#PROJECT_MOUNT=$1
PROJECT_MOUNT=/kubeless
cp /kubeless/publish/*.dll /app
dotnet --additional-deps $PROJECT_MOUNT/publish/*.deps.json --additionalprobingpath $PROJECT_MOUNT/packages /app/Kubeless.WebAPI.dll