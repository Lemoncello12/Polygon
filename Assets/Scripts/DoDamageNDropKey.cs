using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDamageNDropKey : MonoBehaviour
{
    public float Damage = 10f;
    public float hpMax = 10f;
    public float damageRecieved = 10f;
    public float currentHP;
    public GameObject key;
    private GameObject player;
    private AudioSource audio;

    void Start()
    {
        currentHP = hpMax;
        player = GameObject.Find("Player");
        audio = player.GetComponent<AudioSource>();
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
        audio.Play();

        if (currentHP == 0)
        {
            key.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
