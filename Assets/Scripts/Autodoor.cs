using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autodoor : MonoBehaviour
{
    public Vector3 endPos;
    public float speed = 1.0f;
    public float delay = 0.0f;
    private bool moving = false;
    private bool opening = true;
    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MoveDoor(Vector3 goalPos)
    {

    }
}
