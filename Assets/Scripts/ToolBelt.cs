using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Tool { Hand, Stethoscope }

public class ToolBelt : MonoBehaviour
{
    public Tool activeTool = Tool.Hand;

    Button handButton;
    Button stethoscopeButton;

    // Use this for initialization
    void Start()
    {
        handButton = GameObject.Find("Hand").GetComponent<Button>();
        stethoscopeButton = GameObject.Find("Stethoscope").GetComponent<Button>();

        handButton.onClick.AddListener(handOnClick);
        stethoscopeButton.onClick.AddListener(stethoscopeOnClick);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void handOnClick()
    {
        activeTool = Tool.Hand;
        GetComponent<FingerScroll>().enabled = true;
        GetComponent<Stethoscope>().enabled = false;
    }

    void stethoscopeOnClick()
    {
        activeTool = Tool.Stethoscope;
        GetComponent<FingerScroll>().enabled = false;
        GetComponent<Stethoscope>().enabled = true;
    }
}
