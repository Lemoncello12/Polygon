using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GigaBullet : MonoBehaviour
{
    public float tLength = 10f;
    private AudioSource audio;
    private float tRemaining;
    public float damage = 50f;
    // Start is called before the first frame update
    void Start()
    {
        tRemaining = tLength;
        audio = GetComponent<AudioSource>();
        transform.Rotate(Random.Range(-10f,10f) * Time.deltaTime, Random.Range(-10f, 10f) * Time.deltaTime, Random.Range(-10f, 10f) * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (tRemaining > 0)
        {
            tRemaining -= Time.deltaTime;
        }
        else
        {
            gameObject.SetActive(false);
        }
        transform.Rotate(Random.Range(-200f, 200f) * Time.deltaTime, Random.Range(-200f, 200f) * 
            Time.deltaTime, Random.Range(-200f, 200f) * Time.deltaTime);
        transform.Translate(Vector3.forward * 15 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        HealthScript player = other.GetComponent<HealthScript>();
        doDamage enemy = other.GetComponent<doDamage>();
        if (player != null)
        {
            player.TakeDamage(damage);

        }

    }
}
