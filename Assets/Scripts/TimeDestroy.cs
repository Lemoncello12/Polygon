using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TimeDestroy : MonoBehaviour
{
    public int wait = 3000;
    public HealthScript health;
    public GameObject self;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health.alive == false)
        {
            self.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("contact");
            Thread.Sleep(wait);
            self.SetActive(false);
        }

    }
}
