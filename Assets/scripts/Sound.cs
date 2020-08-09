using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]   // custom class allows to be found by unity
public class Sound
{
    public string name;
    public AudioClip clip;

    [Range(0f, 1f)]     // adding slides to unity
    public float volume;
    [Range(0.1f, 3f)]
    public float pitch;

    public bool loop;

    [HideInInspector]   // Hide b/c we automatically create in in AudioManager
    public AudioSource source;  // allows to use the Play() method

}
