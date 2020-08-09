using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    // in the case of multiple audioManager gameObjects
    public static AudioManager instance;

    // Awake is like Start() but is called right before
    void Awake()
    {
        // in the case of multiple audioManager gameObjects
        if(instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        // making the AudioManager persist through Loading Scenes
        DontDestroyOnLoad(gameObject);

        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    void Start()
    {
        // Any sounds you want to play from the start of the game
        // Play("MainSoundTrack");
    }

    public void Play(string name)
    {
        // using System
        Sound s = Array.Find(sounds, sound => sound.name == name);
        // In the case of typo's and other null references
        if (s == null) {
            Debug.LogWarning("Sound: " + name + " was not found!");
            return;
        }
        s.source.Play();

        /*
        In the script for an object to make a sound
        you can use:
        FindObjectOfType<AudioManager>().Play("Sound");     // if the audio is called 'Sound'
        */
    }
}
