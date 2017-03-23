using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stethoscope : MonoBehaviour
{
    public GameObject stethoscope;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.collider.tag == "Human")
                {
                    stethoscope.GetComponent<SpriteRenderer>().enabled = true;
                    stethoscope.transform.position = hit.point;
                }
            }

        }
        else
        {
            stethoscope.GetComponent<SpriteRenderer>().enabled = false;
            stethoscope.transform.position = new Vector3(100f, 100f, 0f);
        }
    }
}
