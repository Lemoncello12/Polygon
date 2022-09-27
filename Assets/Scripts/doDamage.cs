using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doDamage : MonoBehaviour
{
    public float Damage = 10f;

    void Start()
    {

    }

    void Update()
    {

    }

    void OnCollisionEnter(Collision other)
    {
        var health = other.gameObject.GetComponent<HealthScript>();
        if (health != null)
            health.TakeDamage(Damage);
    }

}
