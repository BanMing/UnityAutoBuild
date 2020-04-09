@echo off 

set Unity="C:/Program Files/Unity/Editor/Unity.exe"
set ProjetcPath="C:/BanMingProject/UnityAutoBuild/UnityAutoBuild"
set LogFile="C:/BanMingProject/UnityAutoBuild/UnityAutoBuild/AutoBuildTool/Log/CMDTest1.log"
set LogFile1="C:/BanMingProject/UnityAutoBuild/UnityAutoBuild/AutoBuildTool/Log/CMDTest.log"

echo start build %DATE% %TIME%

REM 调用方法
REM %Unity% -quit -batchmode -projectPath %ProjetcPath% -executeMethod AutoBuildTest.CMDTest -logFile %LogFile%

REM 打包测试
%Unity% -quit -batchmode -projectPath %ProjetcPath% -executeMethod AutoBuildTest.BuildAndroidTest -logFile %LogFile1%

echo end build %DATE% %TIME%
pause
