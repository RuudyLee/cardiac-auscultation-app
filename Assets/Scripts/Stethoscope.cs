using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stethoscope : MonoBehaviour
{
    public GameObject pf_stethoscope;

    GameObject stethoscope;

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
                    if (stethoscope)
                    {
                        stethoscope.transform.position = hit.point;
                    }
                    else
                    {
                        stethoscope = Instantiate(pf_stethoscope, hit.point, Quaternion.identity);
                    }
                }
                else
                {
                    Destroy(stethoscope);
                }
            }

        }
        else
        {
            if (stethoscope)
            {
                Destroy(stethoscope);
            }
        }
    }
}
