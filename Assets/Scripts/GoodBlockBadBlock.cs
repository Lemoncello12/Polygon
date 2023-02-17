using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodBlockBadBlock : MonoBehaviour
{
    public float timerLength = 1f;
    public Material otherMat;
    private Material mat;
    private float timeLeft;
    public bool good = true;
    // Start is called before the first frame update
    void Start()
    {
        timeLeft = timerLength;

    }

    // Update is called once per frame
    void Update()
    {
        if (good)
        {

        }
        else
        {

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
