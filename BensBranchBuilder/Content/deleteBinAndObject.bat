@ECHO OFF
setlocal
SET directoryName=%1
CD .\%directoryName% REM Need to update so that this can be a fully qualified path
ECHO %cd%
SET /P AREYOUSURE=Deleting all bin and obj folders, are you sure (Y to continue)?
IF /I "%AREYOUSURE%" NEQ "Y" EXIT
FOR /d /r . %%d IN ("bin") DO @IF EXIST "%%d" rd /s /q "%%d"
FOR /d /r . %%d IN ("obj") DO @IF EXIST "%%d" rd /s /q "%%d"
 