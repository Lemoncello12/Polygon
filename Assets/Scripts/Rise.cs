using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rise : MonoBehaviour
{
    public float riseSpeed = 5f;
    public HealthScript health;
    private Vector3 place;
    public int limit;
    // Start is called before the first frame update
    void Start()
    {
        place = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < limit)
        {
            transform.Translate(0, riseSpeed * Time.deltaTime, 0);
        }
        
        if (health.alive == false)
        {
            transform.position = place;
        }
    }
}
