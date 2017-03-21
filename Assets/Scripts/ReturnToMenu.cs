using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReturnToMenu : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Button b = GetComponent<Button>();
        b.onClick.AddListener(ReturnOnClick);
    }

    void ReturnOnClick()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
