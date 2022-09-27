using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiseOnScoreWithLimit : MonoBehaviour
{
    public float riseSpeed = 5f;
    //public HealthScript health;
    private Vector3 place;
    public float heightLimit = 12f;
    public scoregame scoring;
    public int scoreToLift = 4;
    // Start is called before the first frame update
    void Start()
    {
        place = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (scoring.score == scoreToLift)
        {
            if (transform.position.y < heightLimit)
            {
                transform.Translate(0, riseSpeed * Time.deltaTime, 0);
            }
        }

        //if (health.alive == false)
        //{
            //contact = false;
            //transform.position = place;
        //}
    }
}
