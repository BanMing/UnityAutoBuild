# unitytest.py
# @Author : BanMing
# @Date   : 2019/4/26 下午2:12:51
# @Desc   : 自动打包测试
# https://cloud.tencent.com/developer/section/1370097

import subprocess
import shutil
import os
import sys

# 官方文档
# https://docs.unity3d.com/Manual/CommandLineArguments.html
UNITYPATH = "C:/Program Files/Unity/Editor/Unity.exe"
PROJECTPATH = "C:/BanMingProject/UnityAutoBuild/UnityAutoBuild"

print("begin test")

# 创建一个项目
# subprocess.call(UNITYPATH+" -quit -batchmode -createProject D:/cmdProject")

# 打开一个指定路径项目
# subprocess.call(UNITYPATH+" -projectPath "+PROJECTPATH)

# 调用unity中方法
print(UNITYPATH+" -batchmode -projectPath "+PROJECTPATH+" -executeMethod AutoBuildTest.CMDTest -quit -logFile "+PROJECTPATH+"/AutoBuildTool/Log/CMDTest1.log")
# subprocess.call(
    # UNITYPATH+" -batchmode -projectPath "+PROJECTPATH+" -executeMethod AutoBuildTest.CMDTest -quit -logFile "+PROJECTPATH+"/AutoBuildTool/Log/CMDTest1.log")
# subprocess.call(
#     UNITYPATH+" -batchmode -projectPath "+PROJECTPATH+" -executeMethod AutoBuildTest.CMDArgsTest sss -quit -logFile Log/CMDTest.log")


# 调用unity中自动打包
# subprocess.call(
#     UNITYPATH+" -batchmode -projectPath "+PROJECTPATH+" -executeMethod AutoBuildTest.BuildAndroidTest -quit -logFile "+PROJECTPATH+"/Package/Log/CMDTest.log")
# print(subprocess.call("git branch"))
# branchs = subprocess.call("git branch")
# print(UNITYPATH+" -batchmode -projectPath "+PROJECTPATH+" -executeMethod Framework.BuildEditor.AutoBuild -quit -logFile "+PROJECTPATH+"/AutoBuildTool/Log/CMDTest1.log")
print("end test")

# # if __name__ =='__main__':
# print(sys.argv)
# print("@@@@@@@@@@@@@")