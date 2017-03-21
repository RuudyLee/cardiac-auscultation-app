using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerScroll : MonoBehaviour
{
    public float zoomSpeed = 1f;

    float previousDistance;

    Transform human;

    Vector3 screenPoint;
    Vector3 offset;

    // Use this for initialization
    void Start()
    {
        previousDistance = 0f;
        human = GameObject.Find("Human").GetComponent<Transform>();
    }

    // Update is called once per frame
    private void Update()
    {
        // double finger zooming
        if (Input.touchCount >= 2)
        {
            Vector2 touch0, touch1;
            float distance;

            touch0 = Input.GetTouch(0).position;
            touch1 = Input.GetTouch(1).position;
            distance = Vector2.Distance(touch0, touch1);

            if (previousDistance != 0f)
            {

                float deltaDistance = (distance - previousDistance) * zoomSpeed * Time.deltaTime;
                
                human.localScale += new Vector3(deltaDistance, deltaDistance, deltaDistance);
                human.localScale = new Vector3(
                    Mathf.Clamp(human.localScale.x, 0.3f, 1.0f),
                    Mathf.Clamp(human.localScale.y, 0.3f, 1.0f),
                    Mathf.Clamp(human.localScale.z, 0.3f, 1.0f));
            }
            previousDistance = distance;
        }
        else if (Input.touchCount > 0)
        {
            // finger panning
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                screenPoint = Camera.main.WorldToScreenPoint(human.transform.position);
                offset = human.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, screenPoint.z));
            }

            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                Vector3 curScreenPoint = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, screenPoint.z);
                Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
                human.transform.position = curPosition;
            }
        }
        else
        {
            previousDistance = 0f;
        }
    }
}
