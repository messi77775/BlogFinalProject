@ECHO OFF

ECHO =====================================

dotnet restore

ECHO=====================================
dotnet ef migrations add InitialMigration  --context BlogFinalProject.Areas.Identity.Data.ApplicationDbContext --output-dir Migrations/

ECHO===================================
dotnet ef database update --context BlogFinalProject.Areas.Identity.Data.ApplicationDbContext
echo =====================

echo off
pause




