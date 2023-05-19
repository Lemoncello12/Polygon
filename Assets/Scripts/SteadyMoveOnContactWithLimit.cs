using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteadyMoveOnContactWithLimit : MonoBehaviour
{
    public float speed = 5f;
    public bool contact = false;
    public float limit = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Entered");
        if (collision.gameObject.tag == ("Player"))
        {
            contact = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < limit)
        {
            if (contact == true)
            {
                transform.Translate(speed * Time.deltaTime, 0, 0);
            }
        }
    }
}
