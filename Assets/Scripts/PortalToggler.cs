using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalToggler : MonoBehaviour
{
    public TeleportalSesame script;

    void Start()
    {
        
    }
 
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered");
        if (other.gameObject.CompareTag("Player"))
        {
            script.toggle();
        }
    }
}
