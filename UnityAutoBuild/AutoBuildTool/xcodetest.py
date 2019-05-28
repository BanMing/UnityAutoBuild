#! /usr/bin/python
# coding=utf-8
# -*- coding:utf8 -*-

from optparse import OptionParser
import subprocess
import os
import time


# unity path and project path
UNITYPATH = "/Applications/Unity/Unity.app/Contents/MacOS/Unity"
PROJECTPATH = "******"
# configuration for iOS build setting
CONFIGURATION = "Release"
SDK = "iphoneos"
PROJECT = "*****"
CACHAPATH = "*****"
TARGET = "****"
SCHEME = "Unity-iPhone"
# 桌面上创建出ipa
EXPORT_MAIN_DIRECTORY = "~/Desktop/"
EXPORT_OPTIONS_PLIST = "exportOptions.plist"


def buildArchivePath(tempName):
    process = subprocess.Popen("pwd", stdout=subprocess.PIPE)
    (stdoutdata, stderrdata) = process.communicate()
    archiveName = "/%s.xcarchive" % (tempName)
    #print("name " + stdoutdata.strip().decode())
    archivePath = CACHAPATH + archiveName
    return archivePath


def cleanArchiveFile(archiveFile):
    cleanCmd = "rm -r %s" % (archiveFile)
    process = subprocess.Popen(cleanCmd, shell=True)
    process.wait()
    print("clean archiveFile: %s" % (archiveFile))


def buildExportDirectory(scheme):
    dateCmd = 'date "+%Y-%m-%d_%H-%M-%S"'
    process = subprocess.Popen(dateCmd, stdout=subprocess.PIPE, shell=True)
    (stdoutdata, stderrdata) = process.communicate()
    exportDirectory = "%s%s%s" % (EXPORT_MAIN_DIRECTORY, scheme, "-test1")
    print("export directory: " + exportDirectory)
    return exportDirectory


def exportArchive(scheme, archivePath):
    exportDirectory = buildExportDirectory(scheme)
    exportCmd = "xcodebuild  -exportArchive -archivePath %s -exportPath %s  -allowProvisioningUpdates -exportOptionsPlist %s" % (
        archivePath, exportDirectory, EXPORT_OPTIONS_PLIST)
    process = subprocess.Popen(exportCmd, shell=True)
    (stdoutdata, stderrdata) = process.communicate()

    signReturnCode = process.returncode
    if signReturnCode != 0:
        print("export %s failed" % scheme)
        return ""
    else:
        return exportDirectory


def buildProject(project, target, output):
    archivePath = buildArchivePath(SCHEME)
    print("arcivePath: " + archivePath)
    process = subprocess.Popen('replace_provision_config', shell=True)
    process.wait()

    time1 = time.time()
    #archiveCmd = 'xcodebuild archive -archivePath %s' + archivePath + ' -scheme ' + "Unity-iPhone" + ' -quiet -configuration %s' + SCHEME
    archiveCmd = 'xcodebuild -project %s -scheme %s -configuration %s archive -archivePath %s -destination generic/platform=iOS' % (
        project, SCHEME, CONFIGURATION, archivePath)
    process = subprocess.Popen(archiveCmd, shell=True)
    process.wait()
    time2 = time.time()
    print("finish archive cmd, used time: " + str(time2 - time1))
    archiveReturnCode = process.returncode
    if archiveReturnCode != 0:
        print("archive project %s failed " % project)
        cleanArchiveFile(archivePath)
    else:
        print("begin export archive")
        time3 = time.time()
        exportDirectory = exportArchive(SCHEME, archivePath)
        time4 = time.time()
        print("finish export archive, used time: " + str(time4 - time3))
        cleanArchiveFile(archivePath)
        if exportDirectory != "":
            print("export archive success")


def showNotification(title, subtitle):
    os.system("osascript -e 'display notification \"" +
              subtitle + "\" with title \"" + title + "\"'")

# 对xcode工程进行build


def xcbuild():
    output = os.path.expanduser("~") + '/Desktop/' + TARGET + '.ipa'
    #comments = options.comments
    print(output)
    buildProject(PROJECT, TARGET, output)


# 先执行unity的build.buildplayer，导出xcode工程
# 在windows平台可以用call调用，但是在Mac下，用Popen执行，不然会报文件无法查找的错误
# 在mac平台下，则需要执行popen的操作来执行命令行
def buildProjectResource():
    print("先导出mac包")
    build = UNITYPATH + ' -quit -batchmode -projectPath ' + \
        PROJECTPATH + ' -executeMethod BuildProject.BuildIOS '
    buildCmd = build + "mac"
    # subprocess.call(buildCmd)
    time1 = time.time()
    #process =  subprocess.Popen(buildCmd, shell = True)
    # process.wait()
    time2 = time.time()
    print("导出mac所用时间： " + str(time2-time1))
    # 再导出apk包
    print("再导出apk")
    buildCmd = build + "android"
    time3 = time.time()
    #process = subprocess.Popen(buildCmd, shell = True)
    # process.wait()
    time4 = time.time()
    print("导出apk所用时间： " + str(time4 - time3))
    # 再导出ios
    print("再导出xcode")
    buildCmd = build + "ios"
    time5 = time.time()
    process = subprocess.Popen(buildCmd, shell=True)
    process.wait()
    time6 = time.time()
    print("导出Xcode工程所用时间： " + str(time6 - time5))


def main():
    buildProjectResource()
    xcbuild()


if __name__ == '__main__':
    main()
