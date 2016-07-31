# GuessNumber .NET Core
[![Build Status](https://travis-ci.org/MiffyLiye/GuessNumber-DNX.svg?branch=master)](https://travis-ci.org/MiffyLiye/GuessNumber-DNX)
[![Build status](https://ci.appveyor.com/api/projects/status/133k8341khalfov8/branch/master?svg=true)](https://ci.appveyor.com/project/MiffyLiye/guessnumber-dnx/branch/master)

## How to start

### Build
```shell
dotnet restore
dotnet build -c Release */*/project.json
```

### Test
```shell
dotnet test -c Release test/*
```

### Change Default Config
Edit ```src/GuessNumber/bin/Release/netcoreapp1.0/appsettings.json```,
change ```InitialChancesCount``` to adjust the difficulty.

### Play
```shell
dotnet src/GuessNumber/bin/Release/netcoreapp1.0/GuessNumber.dll
```
