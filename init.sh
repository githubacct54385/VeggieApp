#!/bin/bash

# Welcome to the initialization script for the app
# You can use this script by running ./init.sh in the VeggieApp directory
# This script does the following:
# 1) installs npm dependencies
# 2) Builds the dotnet core server
# 3) runs the dotnet core server

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

