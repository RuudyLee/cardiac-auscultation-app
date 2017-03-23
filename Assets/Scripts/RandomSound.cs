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

    public AudioClip[] heartSounds;
    public AudioClip[] lungSounds;
    AudioClip[] allSounds;

    Button guessButton;
    public Button[] answerButtons;
    string correctAnswer;
    int correctAnswerPosition;

    public GameManager gameManager;

    // Use this for initialization
    void Start()
    {
        // save a concatenated array of sounds
        allSounds = new AudioClip[heartSounds.Length + lungSounds.Length];
        heartSounds.CopyTo(allSounds, 0);
        lungSounds.CopyTo(allSounds, heartSounds.Length);

        audioSource = GetComponent<AudioSource>();

        guessButton = GameObject.Find("Guess").GetComponent<Button>();
        guessButton.onClick.AddListener(guessOnClick);

        answerButtons[0].onClick.AddListener(answerOnClick0);
        answerButtons[1].onClick.AddListener(answerOnClick1);
        answerButtons[2].onClick.AddListener(answerOnClick2);
        answerButtons[3].onClick.AddListener(answerOnClick3);

        // Begin
        ChooseRandomSound();
    }

    public void ChooseRandomSound()
    {
        // Randomly select a sound to play
        int heartOrLung = Random.Range(0, 2);
        int random;
        if (heartOrLung == 0) // heart
        {
            random = Random.Range(0, heartSounds.Length);
            audioSource.clip = heartSounds[random];
            transform.position = heartLocation.position;
            audioSource.Play();
            correctAnswer = heartSounds[random].name;
        }
        else if (heartOrLung == 1) // lung
        {
            random = Random.Range(0, lungSounds.Length);
            audioSource.clip = lungSounds[random];
            transform.position = lungLocation.position;
            audioSource.Play();
            correctAnswer = lungSounds[random].name;
        }
        else
        {
            Debug.Log("You should never see this");
        }

        // Update answer buttons
        correctAnswerPosition = Random.Range(0, 4);
        for (int i = 0; i < answerButtons.Length; i++)
        {
            List<string> usedWords = new List<string>();
            usedWords.Add(correctAnswer);

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
                    randomWords = Random.Range(0, allSounds.Length);
                } while (usedWords.Contains(allSounds[randomWords].name));
                usedWords.Add(allSounds[randomWords].name);
                answerButtons[i].GetComponentInChildren<Text>().text = allSounds[randomWords].name;
            }
        }
    }

    private void Update()
    {
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
