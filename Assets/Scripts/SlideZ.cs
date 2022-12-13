using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideZ : MonoBehaviour
{
    public float speed = 5f;
    public int limit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < limit)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }

    }
}
