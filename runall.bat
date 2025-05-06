@echo off
:: Build solution in Release:
dotnet build .\College-C#-Assignments.sln -c Release

:: On success, start all executables!:
IF %ERRORLEVEL% EQU 0 (
    echo Build succeeded! Launching binaries...

:: `in()` takes parameters *start, step, and stop*.
    for /L %%i in (1,1,13) do (
    start "projPath=Practical%%i\bin\Release\net8.0-windows\Practical%%i.exe"
    
    :: Add more as needed!
) ELSE (
    echo Build FAILED! No launching EXEs for you!
)
