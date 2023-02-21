using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doDamageIfOn : MonoBehaviour
{
    public float Damage = 10f;
    private bool on;

    void Start()
    {

    }

    void Update()
    {

    }

    public void ON()
    {
        on = true;
    }
    public void OFF()
    {
        on = false;
    }

    void OnCollisionEnter(Collision other)
    {
        if (on)
        {
            var health = other.gameObject.GetComponent<HealthScript>();
            if (health != null)
                health.TakeDamage(Damage);
        }
        
    }
}
