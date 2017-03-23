using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;


public class PracticeLoader : MonoBehaviour
{
    public Text pf_Header;
    public Button pf_Button;

    public AudioClip[] heartSounds;
    public AudioClip[] lungSounds;

    // Use this for initialization
    void Start()
    {
        int counter = 0;

        // Load heart buttons
        GameObject header = Instantiate(pf_Header).gameObject;
        header.transform.SetParent(this.transform);
        header.transform.Translate(0f, -300f - (110f * counter++), 0f);

        foreach (AudioClip ac in heartSounds)
        {
            GameObject button = Instantiate(pf_Button).gameObject;
            button.name = counter.ToString();
            button.transform.SetParent(this.transform);
            button.transform.Translate(0f, -300f - (110f * counter++), 0f);

            button.GetComponent<AudioSource>().clip = ac;
            button.GetComponentInChildren<Text>().text = ac.name;
        }

        // load lung buttons
        counter += 1;

        header = Instantiate(pf_Header).gameObject;
        header.GetComponent<Text>().text = "Lung Sounds";
        header.transform.SetParent(this.transform);
        header.transform.Translate(0f, -300f - (110f * counter++), 0f);

        foreach (AudioClip ac in lungSounds)
        {
            GameObject button = Instantiate(pf_Button).gameObject;
            button.name = counter.ToString();
            button.transform.SetParent(this.transform);
            button.transform.Translate(0f, -300f - (110f * counter++), 0f);

            button.GetComponent<AudioSource>().clip = ac;
            button.GetComponentInChildren<Text>().text = ac.name;
        }

        RectTransform rt = GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(0, 278f * counter);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
