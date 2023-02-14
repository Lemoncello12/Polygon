using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideXSeperateActivate : MonoBehaviour
{
    public float speed = 5f;
    public int limit;
    public bool activated = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activated)
        {
            if (transform.position.x < limit)
            {
                transform.Translate(Time.deltaTime * speed, 0, 0);
            }
            else
            {

            }
        }
    }

    public void ON()
    {
        activated = true;
    }

    public void OFF()
    {
        activated = false;
    }
}
