// Version Incrementor Script for Unity by Francesco Forno (Fornetto Games)
// Inspired by http://forum.unity3d.com/threads/automatic-version-increment-script.144917/
// Modified further by Arazati

using System;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

[InitializeOnLoad]
public class VersionIncrementor
{
    static string[] levels = new string[] { "Assets/Scene.unity" };

    [PostProcessBuildAttribute(1)]
    public static void OnPostprocessBuild(BuildTarget target, string pathToBuiltProject)
    {

    }

    [MenuItem("Build/Build All")]
    private static void BuildAll()
    {
        IncrementVersion(1);

        var p = EditorUtility.SaveFolderPanel("Choose Location of Builds", "", "");
        
        WebGL(p + "//WebGL");
        Windows(p + "//Win32");
    }

    [MenuItem("Build/Build WebGL")]
    private static void BuildWebGL()
    {
        if(!BuildPipeline.isBuildingPlayer)
        {
            IncrementVersion(1);

            WebGL();
        }
    }
    static void WebGL(string path = "")
    {
        if(string.IsNullOrEmpty(path)) path = EditorUtility.SaveFolderPanel("Choose Location of WebGL Build", "", "");

        var bpo = new BuildPlayerOptions();
        bpo.locationPathName = path;
        bpo.scenes = levels;
        bpo.target = BuildTarget.WebGL;

        BuildPipeline.BuildPlayer(bpo);
    }

    [MenuItem("Build/Build Windows")]
    private static void BuildWindows()
    {
        if (!BuildPipeline.isBuildingPlayer)
        {
            IncrementVersion(1);

            Windows();
        }
    }
    static void Windows(string path = "")
    {
        if (string.IsNullOrEmpty(path)) path = EditorUtility.SaveFolderPanel("Choose Location of Windows Build", "", "");

        var bpo = new BuildPlayerOptions();
        bpo.locationPathName = path;
        bpo.scenes = levels;
        bpo.target = BuildTarget.StandaloneWindows;

        BuildPipeline.BuildPlayer(bpo);
    }

    static void IncrementVersion(int buildIncr)
    {
        string[] lines = PlayerSettings.bundleVersion.Split('.');
        
        int OldMajorVersion = int.Parse(lines[0]);
        //int OldMinorVersion = int.Parse(lines[1]);

        //months since the start of 2018
        int MajorVersion = (DateTime.UtcNow.Year - 2018) * 12 + DateTime.UtcNow.Month;
        int MinorVersion = DateTime.UtcNow.DayOfYear;

        int Build = int.Parse(lines[2]) + buildIncr;

        if (MajorVersion != OldMajorVersion) Build = 0;

        PlayerSettings.bundleVersion = MajorVersion.ToString("0") + "." +
                                        MinorVersion.ToString("0") + "." +
                                        Build.ToString("0");
        PlayerSettings.Android.bundleVersionCode = MajorVersion * 1000000 + MinorVersion * 1000 + Build;
    }

    private static void IncreaseBuild()
    {
        IncrementVersion(1);
    }
}
