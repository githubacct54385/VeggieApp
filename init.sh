#!/bin/bash
# Write message to user
echo Hello!  I am going to get things setup for you.
echo


# cd into ClientApp and install npm dependencies
cd ClientApp && npm i

echo 
echo Now building DotNetCore project

# go up one folder and build dotnet core project
cd .. && dotnet build

echo
echo Built project
echo Running project

# run the project
dotnet run

