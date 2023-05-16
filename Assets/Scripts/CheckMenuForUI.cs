using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMenuForUI : MonoBehaviour
{
    public int sceneNum;
    public GameObject button1;
    public GameObject button2;
    public LocalSave script;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (script.newfinished[sceneNum - 1])
        {
            button1.SetActive(true);
        }
        else
        {
            button1.SetActive(false);
        }

        if (script.newsecrets[sceneNum - 1])
        {
            button2.SetActive(true);
        }
        else
        {
            button2.SetActive(false);
        }
    }
}
