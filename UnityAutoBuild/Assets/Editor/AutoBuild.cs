using UnityEngine;
using UnityEditor;

public class AutoBuild : MonoBehaviour
{

    [MenuItem("Build/Build Android Test")]
    static void BuildAndroidTest()
    {
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[] { "Assets/Scene/dome.unity" };
        buildPlayerOptions.locationPathName = "Android Build";
        buildPlayerOptions.target = BuildTarget.Android;
        buildPlayerOptions.options = BuildOptions.None;

        // BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        // BuildSummary summary = report.summary;

        // if (summary.result == BuildResult.Succeeded)
        // {
        //     Debug.Log("Build succeeded: " + summary.totalSize + " bytes");
        // }

        // if (summary.result == BuildResult.Failed)
        // {
        //     Debug.Log("Build failed");
        // }
        var error = BuildPipeline.BuildPlayer(buildPlayerOptions);
        UnityEngine.Debug.Log("error:" + error);
    }
}
