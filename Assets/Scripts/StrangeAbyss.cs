using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrangeAbyss : MonoBehaviour
{
    private GameObject player;
    private scoregame script;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        script = player.GetComponent<scoregame>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            script.Up();
        }
    }
}
