using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Button start;
    public Button practice;
    public Button settings;
    public Button exit;

    // Use this for initialization
    void Start()
    {
        start.onClick.AddListener(startOnClick);
        practice.onClick.AddListener(practiceOnClick);
        settings.onClick.AddListener(settingsOnClick);
        exit.onClick.AddListener(exitOnClick);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void startOnClick()
    {
        SceneManager.LoadScene("Game");
    }

    private void practiceOnClick()
    {
        SceneManager.LoadScene("Practice");
    }

    private void settingsOnClick()
    {
        SceneManager.LoadScene("Settings");
    }

    private void exitOnClick()
    {
        Application.Quit();
    }
}
