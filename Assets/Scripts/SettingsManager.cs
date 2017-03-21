using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    Slider volumeSlider;
    Slider timerSlider;
    Button returnButton;

    GameSettings persistentSettings;

    // Use this for initialization
    void Start()
    {
        volumeSlider = GameObject.Find("VolumeSlider").GetComponent<Slider>();
        timerSlider = GameObject.Find("TimerSlider").GetComponent<Slider>();
        returnButton = GameObject.Find("ReturnButton").GetComponent<Button>();

        volumeSlider.onValueChanged.AddListener(volumeSliderOnValueChanged);
        timerSlider.onValueChanged.AddListener(timerSliderOnValueChanged);
        returnButton.onClick.AddListener(returnButtonOnClick);

        persistentSettings = GameObject.Find("PersistentSettings").GetComponent<GameSettings>();
    }

    private void volumeSliderOnValueChanged(float value)
    {
        persistentSettings.Volume = value;
    }

    private void timerSliderOnValueChanged(float value)
    {
        persistentSettings.roundTimer = (int)value;
    }

    private void returnButtonOnClick()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
