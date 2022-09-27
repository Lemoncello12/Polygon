using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiseOnContact : MonoBehaviour
{
    public float riseSpeed = 5f;
    public HealthScript health;
    private Vector3 place;
    public bool contact = false;
    // Start is called before the first frame update
    void Start()
    {
        place = transform.position;
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
    {   if (contact == true)
        {
            transform.Translate(0, riseSpeed * Time.deltaTime, 0);
            
        }

        if (health.alive == false)
        {
            contact = false;
            transform.position = place;
        }
    }
}
