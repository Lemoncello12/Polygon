using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abyss : MonoBehaviour
{
    public float Damage = 100f;

    void Start()
    {

    }

    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        var health = other.gameObject.GetComponent<HealthScript>();
        if (health != null)
            health.TakeDamage(Damage);
    }
}
