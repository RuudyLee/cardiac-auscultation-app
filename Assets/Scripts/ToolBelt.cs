using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Tool { Hand, Diaphragm, Bell }

public class ToolBelt : MonoBehaviour
{
    public Tool activeTool = Tool.Hand;

    Button handButton;
    Button stethoscopeButton;

    Tool previousTool = Tool.Diaphragm;

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
        if (activeTool != Tool.Hand)
        {
            previousTool = activeTool;
        }

        activeTool = Tool.Hand;
        GetComponent<FingerScroll>().enabled = true;
        GetComponent<Stethoscope>().enabled = false;
    }

    void stethoscopeOnClick()
    {
        GetComponent<FingerScroll>().enabled = false;
        GetComponent<Stethoscope>().enabled = true;

        if (activeTool == Tool.Hand)
        {
            activeTool = previousTool;
        }
        else if (activeTool == Tool.Diaphragm)
        {
            activeTool = Tool.Bell;
            stethoscopeButton.GetComponentInChildren<Text>().text = "Steth.\n(B)";
        }
        else if (activeTool == Tool.Bell)
        {
            activeTool = Tool.Diaphragm;
            stethoscopeButton.GetComponentInChildren<Text>().text = "Steth.\n(D)";
        }

        Debug.Log(activeTool);
    }
}
