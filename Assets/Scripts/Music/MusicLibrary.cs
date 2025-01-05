using UnityEngine;

[System.Serializable]
public struct MusicTrack
{
    public string trackName;
    public AudioClip audioClip;
}

public class MusicLibrary : MonoBehaviour
{
    [Header("Music Settings")]
    [SerializeField] private MusicTrack[] tracks;

    public AudioClip GetClipFromName(string trackName)
    {
        foreach (var track in tracks)
        {
            if (track.trackName == trackName)
            {
                return track.audioClip;
            }
        }

        return null;
    }
}
