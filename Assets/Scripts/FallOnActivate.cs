using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallOnActivate : MonoBehaviour
{
    public float fallSpeed = 5f;
    public int limit;
    public bool on = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (on)
        {
            if (transform.position.z > limit)
            {
                transform.Translate(0, 0, -fallSpeed * Time.deltaTime);
            }
        }
        

    }

    public void ON()
    {
        on = true;
    }
}
