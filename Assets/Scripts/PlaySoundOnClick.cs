using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaySoundOnClick : MonoBehaviour
{    
    Button button;
    AudioSource source;

    AudioSource[] allAudioSources;
    
    // Use this for initialization
    void Start()
    {
        button = GetComponent<Button>();
        source = GetComponent<AudioSource>();

        button.onClick.AddListener(playSoundOnClick);
    }

    void playSoundOnClick()
    {
        // stop all other sounds playing
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];

        foreach (AudioSource s in allAudioSources)
        {
            s.Stop();
        }

        source.Play();
    }
}
