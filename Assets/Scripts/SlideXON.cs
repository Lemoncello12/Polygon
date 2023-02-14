using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideXON : MonoBehaviour
{
    public SlideXSeperateActivate script1;
    public SideSideActivated script2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            script1.ON();
            script2.ON();
        }
        
    }
}
