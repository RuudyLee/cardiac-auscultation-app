using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pair<T, U>
{
    public Pair()
    {
    }

    public Pair(T first, U second)
    {
        this.First = first;
        this.Second = second;
    }

    public T First { get; set; }
    public U Second { get; set; }
};

public class GameManager : MonoBehaviour
{
    public Text timer;
    public Text streak;
    public AudioSource audioSource;

    GameSettings settings;
    float internalTimer;

    int currStreak;

    // Use this for initialization
    void Start()
    {
        // Retrieve settings
        settings = GameObject.Find("PersistentSettings").GetComponent<GameSettings>();

        if (settings != null)
        {
            internalTimer = settings.roundTimer + 1;
            audioSource.volume = settings.Volume;
        }
        else
        {
            internalTimer = 31f;
            audioSource.volume = 1f;
        }

        currStreak = 0;
        streak.text = "Streak: " + currStreak.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (internalTimer > 0)
        {
            string timeAsText = ((int)internalTimer).ToString();
            timer.text = timeAsText;
            internalTimer -= Time.deltaTime;
        }
        else
        {
            SceneManager.LoadScene("Main Menu");
        }
    }

    public void ScorePoint()
    {
        currStreak++;
        streak.text = "Streak: " + currStreak.ToString();

        if (settings != null)
        {
            internalTimer = settings.roundTimer + 1;
        }
        else
        {
            internalTimer = 31f;
        }
    }
}
