#!/bin/zsh

# Make executable - chmod +x newproj.sh
# Exit on error
set -e

# Check for argument
if [[ -z "$1" ]]; then
  echo "Usage: ./newproj.sh <name>"
  exit 1
fi

projName=$1

echo "Creating project: $projName"
dotnet new console -o "$projName"

dotnet sln add "$projName/$projName.csproj"

dotnet add "$projName" reference Common

echo "Created $projName and linked to Common!"
echo "Run it with: dotnet run --project $projName"