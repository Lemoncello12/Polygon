using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float xSpinSpeed;
    public float ySpinSpeed;
    public float zSpinSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Time.deltaTime * xSpinSpeed * 10, Time.deltaTime * ySpinSpeed * 10, Time.deltaTime * zSpinSpeed * 10);
    }
}
