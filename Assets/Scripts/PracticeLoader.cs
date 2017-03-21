using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;


public class PracticeLoader : MonoBehaviour
{
    public Text pf_Header;
    public Button pf_Button;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(LoadSounds());

    }

    IEnumerator LoadSounds()
    {
        int counter = 0;

        // Load heart sounds
        GameObject header = Instantiate(pf_Header).gameObject;
        header.transform.SetParent(this.transform);
        header.transform.Translate(0f, -250f - (110f * counter++), 0f);

        DirectoryInfo dir = new DirectoryInfo("Assets/Sounds/Heart");
        FileInfo[] info = dir.GetFiles("*.wav");


        foreach (FileInfo fi in info)
        {
            WWW path = new WWW("file://" + fi.FullName);

            while (!path.isDone)
                yield return null;

            GameObject button = Instantiate(pf_Button).gameObject;
            button.name = counter.ToString();
            button.transform.SetParent(this.transform);
            button.transform.Translate(720f, 2310f - (110f * counter++), 0f);
            AudioClip ac = path.GetAudioClip(false);

            button.GetComponent<AudioSource>().clip = ac;
            button.GetComponentInChildren<Text>().text = fi.Name.Substring(0, fi.Name.Length - 4);
        }

        // load lung sounds
        counter += 1;

        header = Instantiate(pf_Header).gameObject;
        header.GetComponent<Text>().text = "Lung Sounds";
        header.transform.SetParent(this.transform);
        header.transform.Translate(720f, 2310f - (110f * counter++), 0f);

        dir = new DirectoryInfo("Assets/Sounds/Lungs");
        info = dir.GetFiles("*.wav");


        foreach (FileInfo fi in info)
        {
            WWW path = new WWW("file://" + fi.FullName);

            while (!path.isDone)
                yield return null;

            GameObject button = Instantiate(pf_Button).gameObject;
            button.name = counter.ToString();
            button.transform.SetParent(this.transform);
            button.transform.Translate(720f, 2310f - (110f * counter++), 0f);
            AudioClip ac = path.GetAudioClip(false);

            button.GetComponent<AudioSource>().clip = ac;
            button.GetComponentInChildren<Text>().text = fi.Name.Substring(0, fi.Name.Length - 4);
        }

        RectTransform rt = GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(0, 278f * counter);
    }


    // Update is called once per frame
    void Update()
    {

    }
}
