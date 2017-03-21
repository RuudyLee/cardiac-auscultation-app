using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;


public class RandomSound : MonoBehaviour
{
    // for debugging
    public Text debugText;

    public Transform heartLocation;
    public Transform lungLocation;

    AudioSource audioSource;

    List<Pair<string, AudioClip>> heartSounds;
    List<Pair<string, AudioClip>> lungSounds;

    // Use this for initialization
    void Start()
    {
        heartSounds = new List<Pair<string, AudioClip>>();
        lungSounds = new List<Pair<string, AudioClip>>();

        // Load all sounds
        StartCoroutine(LoadSounds());
        
        audioSource = GetComponent<AudioSource>();
    }

    public void ChooseRandomSound()
    {
        int heartOrLung = Random.Range(0, 2);
        if (heartOrLung == 0) // heart
        {
            int random = Random.Range(0, heartSounds.Count);
            audioSource.clip = heartSounds[random].Second;
            transform.position = heartLocation.position;
            audioSource.Play();
            debugText.text = "Now Playing:\n" + heartSounds[random].First;
        }
        else if (heartOrLung == 1) // lung
        {
            int random = Random.Range(0, lungSounds.Count);
            audioSource.clip = lungSounds[random].Second;
            transform.position = lungLocation.position;
            audioSource.Play();
            debugText.text = "Now Playing:\n" + lungSounds[random].First;
        }
        else
        {
            Debug.Log("You should never see this");
        }
    }

    IEnumerator LoadSounds()
    {
        // Load heart sounds
        DirectoryInfo dir = new DirectoryInfo("Assets/Sounds/Heart");
        FileInfo[] info = dir.GetFiles("*.wav");


        foreach (FileInfo fi in info)
        {
            WWW path = new WWW("file://" + fi.FullName);

            while (!path.isDone)
                yield return null;

            AudioClip ac = path.GetAudioClip(false);
            heartSounds.Add(new Pair<string, AudioClip>(fi.Name.Substring(0, fi.Name.Length - 4), ac));
        }

        // load lung sounds     

        dir = new DirectoryInfo("Assets/Sounds/Lungs");
        info = dir.GetFiles("*.wav");


        foreach (FileInfo fi in info)
        {
            WWW path = new WWW("file://" + fi.FullName);

            while (!path.isDone)
                yield return null;

            AudioClip ac = path.GetAudioClip(false);
            lungSounds.Add(new Pair<string, AudioClip>(fi.Name.Substring(0, fi.Name.Length - 4), ac));
        }

        ChooseRandomSound();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ChooseRandomSound();
        }
    }
}
