using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiseOnActivate : MonoBehaviour
{
    public float riseSpeed = 5f;
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
            if (transform.position.y < limit)
            {
                transform.Translate(0, 0, riseSpeed * Time.deltaTime);
            }
        }


    }

    public void ON()
    {
        on = true;
    }
}
