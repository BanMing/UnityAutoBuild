using UnityEngine;
using UnityEditor;
using UnityEditor.Build.Reporting;
using System;

public class AutoBuildTest
{

    [MenuItem("Build Test/Build Android Test")]
    static void BuildAndroidTest()
    {
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[] { "Assets/Scene/dome.unity" };
        PlayerSettings.applicationIdentifier = "com.test.autobuild";
        buildPlayerOptions.locationPathName = "Package/Android Build.apk";
        buildPlayerOptions.target = BuildTarget.Android;
        buildPlayerOptions.options = BuildOptions.CompressWithLz4;
        var error = BuildPipeline.BuildPlayer(buildPlayerOptions);
        //if (!string.IsNullOrEmpty(error))
        //{
        //    UnityEngine.Debug.Log("error:" + error);
        //}
        //else
        //{
        //    Debug.Log("build success!");
        //}
    }

    [MenuItem("Build Test/Build iOS Test")]
    static void BuildiOSTest()
    {
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[] { "Assets/Scene/dome.unity" };
        buildPlayerOptions.locationPathName = "Package/iOSBuild";
        buildPlayerOptions.target = BuildTarget.iOS;
        buildPlayerOptions.options = BuildOptions.None;
        BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        //report.
        //if (!string.IsNullOrEmpty(error))
        //{
        //    UnityEngine.Debug.Log("error:" + error);
        //}
        //else
        //{
        //    Debug.Log("build success!");
        //}
    }

    [MenuItem("Build Test/Build PC Test")]
    static void BuildPCTest()
    {
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[] { "Assets/Scene/dome.unity" };
        buildPlayerOptions.locationPathName = "Package/2/PcBuild.exe";
        buildPlayerOptions.target = BuildTarget.StandaloneWindows;
        buildPlayerOptions.options = BuildOptions.AllowDebugging;

        BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
    }
    [MenuItem("Build Test/Test")]
    static void BuildTest()
    {
        //Debug.Log((BuildOptions.AllowDebugging | BuildOptions.Development));
        //Debug.Log((int)(BuildOptions.AllowDebugging | BuildOptions.Development));
        //Debug.Log((BuildOptions.StrictMode));
        Debug.Log(((int)BuildOptions.StrictMode));
        //var test = (BuildOptions)(513);
        //Debug.Log(test);
        var a = (BuildOptions)Enum.Parse(typeof(BuildOptions), "Development");
        Debug.Log(a);

        var b = (BuildOptions)Enum.Parse(typeof(BuildOptions), "Development", true);
        Debug.Log(b);

        var c= (BuildOptions)Enum.Parse(typeof(BuildOptions), "513");
        Debug.Log(c);
    }

    /// <summary>
    /// 直接调用调用
    /// </summary>
    static void CMDTest()
    {
        System.Console.WriteLine("Console CMDTest!");
        Debug.Log("Unity Log CMDTest!");
    }

    /// <summary>
    /// 接收参数修改
    /// </summary>
    static void CMDArgsTest()
    {
        var args = System.Environment.GetCommandLineArgs();
        for (int i = 0; i < args.Length; i++)
        {
            Debug.Log("args " + i + " " + args[i]);
        }
    }
}
