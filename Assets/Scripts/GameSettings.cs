using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    [Header("Game")]
    [Range(5, 120)]
    public int roundTimer = 30;

    [Space(10)]
    [Header("Audio")]
    [Range(0.0f, 1.0f)]
    public float m_Volume = 1.0f;

    public float Volume
    {
        get { return m_Volume; }
        set
        {
            if (m_Volume == value) return;
            m_Volume = value;

            AudioListener.volume = value;
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    // Called when script is loaded and when value is changed
    private void OnValidate()
    {
        AudioListener.volume = Volume;
    }
}
