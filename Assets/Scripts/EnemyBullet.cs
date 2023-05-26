using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float timerLength = 10f;
    private AudioSource audio;
    private float timeRemaining;
    public float damage = 50f;
    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = timerLength;
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            gameObject.SetActive(false);
        }
        transform.Translate(Vector3.forward * 10 * Time.deltaTime);
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
