@ECHO OFF
title: Creation of Identity

ECHO =============================================================
dotnet-aspnet-codegenerator identity --dbContext ApplicationDbContext --files "Account.Login;Account.Logout;Account.Register"
ECHO===============================================================
dotnet restore
ECHO ==============================================================
dotnet build
echo off
pause
