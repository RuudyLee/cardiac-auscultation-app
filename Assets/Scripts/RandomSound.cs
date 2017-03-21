using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RandomSound : MonoBehaviour
{
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

    public GameManager gameManager;

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

        answerButtons[0].onClick.AddListener(answerOnClick0);
        answerButtons[1].onClick.AddListener(answerOnClick1);
        answerButtons[2].onClick.AddListener(answerOnClick2);
        answerButtons[3].onClick.AddListener(answerOnClick3);
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
        }
        else if (heartOrLung == 1) // lung
        {
            random = Random.Range(0, lungSounds.Count);
            audioSource.clip = lungSounds[random].Second;
            transform.position = lungLocation.position;
            audioSource.Play();
            correctAnswer = lungSounds[random].First;
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
        if (audioSource.isPlaying)
        {
            Debug.Log("HELLO");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            ChooseRandomSound();
        }
    }

    void answerOnClick0()
    {
        Debug.Log("0");
        if (correctAnswerPosition == 0)
        {
            gameManager.ScorePoint();
            ChooseRandomSound();
        }
        else
        {
            SceneManager.LoadScene("Main Menu");
        }
    }

    void answerOnClick1()
    {
        Debug.Log("1");
        if (correctAnswerPosition == 1)
        {
            gameManager.ScorePoint();
            ChooseRandomSound();
        }
        else
        {
            SceneManager.LoadScene("Main Menu");
        }
    }

    void answerOnClick2()
    {
        Debug.Log("2");
        if (correctAnswerPosition == 2)
        {
            gameManager.ScorePoint();
            ChooseRandomSound();
        }
        else
        {
            SceneManager.LoadScene("Main Menu");
        }
    }

    void answerOnClick3()
    {
        Debug.Log("3");
        if (correctAnswerPosition == 3)
        {
            gameManager.ScorePoint();
            ChooseRandomSound();
        }
        else
        {
            SceneManager.LoadScene("Main Menu");
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
