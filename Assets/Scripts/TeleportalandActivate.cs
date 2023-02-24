using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportalandActivate : MonoBehaviour
{
    public GameObject teleported;
    public FallOnActivate script1;
    public RiseOnActivate script2;
    private Vector3 goTo;
    // Start is called before the first frame update
    void Start()
    {
        goTo = teleported.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("StorageCube"))
        {
            other.gameObject.transform.position = goTo;
            script1.ON();
            script2.ON();
        }
    }
}
