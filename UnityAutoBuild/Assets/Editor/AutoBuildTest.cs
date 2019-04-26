using UnityEngine;
using UnityEditor;

public class AutoBuildTest : MonoBehaviour
{

    [MenuItem("Build Test/Build Android Test")]
    static void BuildAndroidTest()
    {
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[] { "Assets/Scene/dome.unity" };
        buildPlayerOptions.locationPathName = "Package/Android Build.apk";
        buildPlayerOptions.target = BuildTarget.Android;
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

    static void CMDTest()
    {
        System.Console.WriteLine("Console CMDTest!");
        Debug.Log("CMDTest!");
    }
}
