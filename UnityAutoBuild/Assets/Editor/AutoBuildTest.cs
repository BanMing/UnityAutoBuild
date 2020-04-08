using UnityEngine;
using UnityEditor;

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
        buildPlayerOptions.options = BuildOptions.Il2CPP | BuildOptions.CompressWithLz4;
        var error = BuildPipeline.BuildPlayer(buildPlayerOptions);
        if (!string.IsNullOrEmpty(error))
        {
            UnityEngine.Debug.Log("error:" + error);
        }
        else
        {
            Debug.Log("build success!");
        }
    }

    [MenuItem("Build Test/Build iOS Test")]
    static void BuildiOSTest()
    {
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[] { "Assets/Scene/dome.unity" };
        buildPlayerOptions.locationPathName = "Package/iOSBuild";
        buildPlayerOptions.target = BuildTarget.iOS;
        buildPlayerOptions.options = BuildOptions.None;
        var error = BuildPipeline.BuildPlayer(buildPlayerOptions);
        if (!string.IsNullOrEmpty(error))
        {
            UnityEngine.Debug.Log("error:" + error);
        }
        else
        {
            Debug.Log("build success!");
        }
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
