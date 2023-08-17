using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public static class SongDataLoader  
{
    public static bool isLoaded { get; private set; }

    public static SongData dataLoad;
    public static VideoClip clipLoad;

    public static void Load(string songName)
    {
        isLoaded = false;
        dataLoad = null;
        clipLoad = null;

       dataLoad = JsonUtility.FromJson<SongData>(Resources.Load<TextAsset>($"SongDatum/{songName}").ToString());
        clipLoad = Resources.Load<VideoClip>($"SongClips/{songName}");
        isLoaded = true;
    }
}
