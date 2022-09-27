using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreNumbers : MonoBehaviour
{
    public float theAge = 13.2f;
    public int ourAge = 12;

    // Start is called before the first frame update
    void Start()
    {
        AddThese();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void AddThese()
    {
        print(theAge - ourAge);
        print(theAge + ourAge * 2);
        print(theAge / ourAge);
    }
}
