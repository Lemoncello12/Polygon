using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinOnScore : MonoBehaviour
{
    public float spinSpeed = 0.9f;
    //public HealthScript health;
    private Quaternion angle;
    public float spinLimit = 90f;
    public scoregame scoring;
    public int scoreToSpin = 4;
    // Start is called before the first frame update
    void Start()
    {
        angle = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (scoring.score == scoreToSpin)
        {
            transform.eulerAngles = new Vector3(90, 0, 0);

        }

        //if (health.alive == false)
        //{
        //contact = false;
        //transform.rotation = angle;
        //}
    }
}
