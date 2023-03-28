using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawn : MonoBehaviour
{
    public float timerLength = 10f;
    private float timeRemaining;
    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = timerLength;
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
        gameObject.SetActive(false);
    }
}
