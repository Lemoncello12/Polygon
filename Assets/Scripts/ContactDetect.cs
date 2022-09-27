using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDetect : MonoBehaviour
{
    public RiseOnExternalContactWithLimit notifyOf;

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Entered");
        if (collision.gameObject.tag == ("Player"))
        {
            notifyOf.contact = true;
        }
    }
}
