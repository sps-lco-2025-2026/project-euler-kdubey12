#!/usr/bin/env pwsh

$ErrorActionPreference = "Stop"

if ($args.Count -lt 1) {
    Write-Host "Usage: ./newproj.ps1 <name>"
    exit 1
}

$projName = $args[0]


Write-Host "Creating project: $projName"
dotnet new console -o $projName

dotnet sln add "$projName/$projName.csproj"

dotnet add $projName reference Common


Write-Host "Created $projName and linked to Common!"
Write-Host "Run it with: dotnet run --project $projName"