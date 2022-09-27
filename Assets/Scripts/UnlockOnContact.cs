using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockOnContact : MonoBehaviour
{
    public GameObject unlockee;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            unlockee.SetActive(true);
        }

    }
}
