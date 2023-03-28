using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doDamage : MonoBehaviour
{
    public float Damage = 10f;
    public float hpMax = 10f;
    public float damageRecieved = 10f;
    public float currentHP;

    void Start()
    {
        currentHP = hpMax;
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

    public void takeDamage()
    {
        currentHP = currentHP - damageRecieved;

        if (currentHP == 0)
        {
            gameObject.SetActive(false);
        }
    }

}
