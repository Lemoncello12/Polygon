using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddNumbers : MonoBehaviour
{
    public float myAge = 12f;
    public float classAgeAverage = 12.9f;
    // Start is called before the first frame update
    void Start()
    {
        print(myAge + classAgeAverage);
        print(myAge / 2);
        print(myAge * classAgeAverage);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
