using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchScript : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {



    }

    private void OnGUI()
    {

        foreach (Touch touch in Input.touches)
        {
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            string message = "";
            message += "ID: " + touch.fingerId + "\n";
            message += "Phase:" + touch.phase.ToString() + "\n";
            message += "TapCount: " + touch.tapCount + "\n";
            message += "Pos X: " + ray.origin.x + "\n";
            message += "Pos Y: " + ray.origin.y + "\n";
            message += " dPos X: " + touch.deltaPosition.x + "\n";
            message += " dPos Y: " + touch.deltaPosition.y + "\n";

            transform.position = new Vector3(ray.origin.x, ray.origin.y, 0.0f);

            int num = touch.fingerId;
            GUIStyle style = new GUIStyle();
            style.fontSize = 50;
            GUI.Label(new Rect(0 + 520 * num, 0, 480, 400), message, style);
        }
    }
}
