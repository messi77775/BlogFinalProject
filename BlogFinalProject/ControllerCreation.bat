
@ECHO OFF

ECHO ===================================
dotnet aspnet-codegenerator controller -name BlogUsersController -m BlogUser -dc BlogUserContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries
ECHO =================================
dotnet build
echo off
pause