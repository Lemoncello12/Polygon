using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportalSesame : MonoBehaviour
{
    public GameObject teleported1;
    public GameObject teleported2;
    public bool goTo1or2 = false;
    private Vector3 goTo1;
    private Vector3 goTo2;
    private Vector3 goTo;
    // Start is called before the first frame update
    void Start()
    {
        goTo1 = teleported1.transform.position;
        goTo2 = teleported2.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (goTo1or2)
        {
            goTo = goTo2;
        }
        else
        {
            goTo = goTo1;
        }

        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("StorageCube"))
        {
            other.gameObject.transform.position = goTo;
        }
    }
    
    public void toggle()
    {
        goTo1or2 = !goTo1or2;

        teleported1.SetActive(!goTo1or2);
        teleported2.SetActive(goTo1or2);
    }

    public void pushStart()
    {
        goTo1or2 = true;

        teleported1.SetActive(!goTo1or2);
        teleported2.SetActive(goTo1or2);
    }

    public void pushExit()
    {
        goTo1or2 = false;

        teleported1.SetActive(!goTo1or2);
        teleported2.SetActive(goTo1or2);
    }
}
