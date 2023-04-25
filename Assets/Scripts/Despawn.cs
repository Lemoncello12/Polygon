using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawn : MonoBehaviour
{
    public float timerLength = 10f;
    private AudioSource audio;
    private float timeRemaining;
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
        doDamage enemy = other.GetComponent<doDamage>();

        if (enemy != null)
        {
            enemy.takeDamage();
        }
        else
        {
            DoDamageNDropKey enemy2 = other.GetComponent<DoDamageNDropKey>();
            if (enemy2 != null)
            {
                enemy2.takeDamage();
            }
        }
        gameObject.SetActive(false);
    }
}
