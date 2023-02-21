using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodBlockBadBlock : MonoBehaviour
{
    public float timerLength = 1f;
    public Material badMat;
    private Material goodMat;
    private float timeLeft;
    public bool good = true;
    private doDamageIfOn script;
    // Start is called before the first frame update
    void Start()
    {
        timeLeft = timerLength;
        goodMat = GetComponent<MeshRenderer>().material;
        script = GetComponent<doDamageIfOn>();

        if (good)
        {
            GetComponent<MeshRenderer>().material = goodMat;
            script.OFF();
        }
        else
        {
            GetComponent<MeshRenderer>().material = badMat;
            script.ON();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (good)
        {
            GetComponent<MeshRenderer>().material = goodMat;
            script.OFF();
        }
        else
        {
            GetComponent<MeshRenderer>().material = badMat;
            script.ON();
        }

        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
        }
        else
        {
            good = !good;
            timeLeft = timerLength;
        }
    }
}
