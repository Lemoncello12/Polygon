using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceptacleSpins : MonoBehaviour
{
    public float xSpinSpeed;
    public float ySpinSpeed;
    public float zSpinSpeed;
    public bool startOn = true;
    private bool spin;

    // Start is called before the first frame update
    void Start()
    {
        spin = startOn;
    }

    // Update is called once per frame
    void Update()
    {
        if (spin)
        {
            transform.Rotate(Time.deltaTime * xSpinSpeed * 10, Time.deltaTime * ySpinSpeed * 10, Time.deltaTime * zSpinSpeed * 10);
        }
    }

    public void pushStart()
    {
        spin = !startOn;
    }

    public void pushExit()
    {
        spin = startOn;
    }
}
