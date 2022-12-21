using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeReceptacle : MonoBehaviour
{
    public TeleportalSesame script;

    void Start()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Triggered");
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("StorageCube"))
        {
            script.pushStart();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("StorageCube"))
        {
            script.pushExit();
        }
    }
}
