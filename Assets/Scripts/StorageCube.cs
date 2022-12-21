using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageCube : MonoBehaviour
{
    private Vector3 home;
    // Start is called before the first frame update
    void Start()
    {
        home = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter (Collision other)
    {
        if (other.gameObject.CompareTag("Abyss"))
        {
            transform.position = home;
        }
    }
}
