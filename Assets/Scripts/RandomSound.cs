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
    List<Pair<string, AudioClip>> allSounds;

    Button guessButton;
    public Button[] answerButtons;
    string correctAnswer;
    int correctAnswerPosition;

    // Use this for initialization
    void Start()
    {
        heartSounds = new List<Pair<string, AudioClip>>();
        lungSounds = new List<Pair<string, AudioClip>>();
        allSounds = new List<Pair<string, AudioClip>>();

        // Load all sounds
        StartCoroutine(LoadSounds());

        audioSource = GetComponent<AudioSource>();

        guessButton = GameObject.Find("Guess").GetComponent<Button>();
        guessButton.onClick.AddListener(guessOnClick);
    }

    public void ChooseRandomSound()
    {
        // Randomly select a sound to play
        int heartOrLung = Random.Range(0, 2);
        int random;
        if (heartOrLung == 0) // heart
        {
            random = Random.Range(0, heartSounds.Count);
            audioSource.clip = heartSounds[random].Second;
            transform.position = heartLocation.position;
            audioSource.Play();
            correctAnswer = heartSounds[random].First;
            debugText.text = "Now Playing:\n" + heartSounds[random].First;
        }
        else if (heartOrLung == 1) // lung
        {
            random = Random.Range(0, lungSounds.Count);
            audioSource.clip = lungSounds[random].Second;
            transform.position = lungLocation.position;
            audioSource.Play();
            correctAnswer = lungSounds[random].First;
            debugText.text = "Now Playing:\n" + lungSounds[random].First;
        }
        else
        {
            Debug.Log("You should never see this");
        }

        // Update answer buttons
        correctAnswerPosition = Random.Range(0, 4);
        for (int i = 0; i < answerButtons.Length; i++)
        {
            if (i == correctAnswerPosition)
            {
                // place correct answer here
                answerButtons[i].GetComponentInChildren<Text>().text = correctAnswer;
            }
            else
            {
                // Ensure the incorrect choices don't have the same label
                int randomWords;
                do
                {
                    randomWords = Random.Range(0, allSounds.Count);
                } while (randomWords == correctAnswerPosition);

                answerButtons[i].GetComponentInChildren<Text>().text = allSounds[randomWords].First;
            }
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

        // store a concatenated list
        allSounds.AddRange(heartSounds);
        allSounds.AddRange(lungSounds);

        // boot it up!
        ChooseRandomSound();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ChooseRandomSound();
        }
    }

    void guessOnClick()
    {
        // Toggle buttons
        foreach (Button b in answerButtons)
        {
            b.gameObject.SetActive(!b.gameObject.activeInHierarchy);
        }
    }
}
