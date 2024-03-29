﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathMove : MonoBehaviour
{
    public float maxMove = 12.2f;
    public float backForth = 4.2f;
    public string axis = "X";
    private Vector3 vector;


    // Start is called before the first frame update
    void Start()
    {
        vector = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (axis == "X")
        {
            transform.position = new Vector3((maxMove * Mathf.Sin(Time.time * backForth)) + vector.x, vector.y, vector.z);
        }
        if (axis == "Y")
        {
            transform.position = new Vector3(vector.x, maxMove * (Mathf.Sin(Time.time * backForth)) + vector.y, vector.z);
        }
        if (axis == "Z")
        {
            transform.position = new Vector3(vector.x, vector.y, (maxMove * Mathf.Sin(Time.time * backForth)) + vector.z);
        }
    }
}
