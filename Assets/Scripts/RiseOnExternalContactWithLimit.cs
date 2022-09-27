using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiseOnExternalContactWithLimit : MonoBehaviour
{
    public float riseSpeed = 5f;
    public HealthScript health;
    private Vector3 place;
    public bool contact = false;
    public float heightLimit = 0f;

    // Start is called before the first frame update
    void Start()
    {
        place = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < heightLimit)
        {
            if (contact == true)
            {
                transform.Translate(0, riseSpeed * Time.deltaTime, 0);

            }
        }


        if (health.alive == false)
        {
            contact = false;
            transform.position = place;
        }
    }
}
