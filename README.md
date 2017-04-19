# GuessNumber .NET Core
[![Build status](https://ci.appveyor.com/api/projects/status/133k8341khalfov8/branch/master?svg=true)](https://ci.appveyor.com/project/MiffyLiye/guessnumber-dnx/branch/master)

## How to start

### Build
```powershell
dotnet restore
dotnet build -c Release .\GuessNumber.sln
```

### Test
```powershell
dotnet test -c Release .\test\GuessNumberTest\GuessNumberTest.csproj
```

### Change Default Config
Edit ```.\src\GuessNumber\bin\Release\netcoreapp1.0\appsettings.json```,
change ```InitialChancesCount``` to adjust the difficulty.

### Play
```powershell
dotnet  .\src\GuessNumber\bin\Release\netcoreapp1.0\GuessNumber.dll
```
