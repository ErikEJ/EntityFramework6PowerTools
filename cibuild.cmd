.nuget\nuget restore .\ErikEJ.EntityFramework.SqlServer.sln -DisableParallelProcessing -NonInteractive -Verbosity quiet -Source https://api.nuget.org/v3/index.json

SET CI=True

msbuild ErikEJ.EntityFramework.SqlServer.sln /p:configuration=Release /v:m

rem dotnet nuget sign "ErikEJ.EntityFramework.SqlServer.6.6.8.nupkg" --certificate-fingerprint xxxx --timestamper http://time.certum.pl

REM --certificate-fingerprint = certificate thumbprint vist i Certmgr/SimplySign
