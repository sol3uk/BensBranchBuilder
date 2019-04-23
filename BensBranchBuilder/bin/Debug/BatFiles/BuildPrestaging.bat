call "C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\Common7\Tools\VsDevCmd.bat"
echo cd C:\JL\TMS\PreStaging
cd C:\JL\TMS\PreStaging
echo ..\NuGet.exe restore .\web\JobLogic.Published.sln
..\NuGet.exe restore .\web\JobLogic.Published.sln
echo MSBuild.exe .\web\Web\JobLogic\JobLogic.csproj /property:WarningLevel=0
MSBuild.exe .\web\Web\JobLogic\JobLogic.csproj /property:WarningLevel=0
pause