using UnityEngine;

[System.Serializable]
public struct SoundEffect
{
    public string groupID;
    public AudioClip[] clips;
}

public class SoundLibrary : MonoBehaviour
{
    [Header("Sound Settings")]
    [SerializeField] private SoundEffect[] soundEffects;

    public AudioClip GetClipFromName(string soundName)
    {
        foreach (var soundEffect in soundEffects)
        {
            if (soundEffect.groupID == soundName)
            {
                return soundEffect.clips[Random.Range(0, soundEffect.clips.Length)];
            }
        }

        return null;
    }
}
