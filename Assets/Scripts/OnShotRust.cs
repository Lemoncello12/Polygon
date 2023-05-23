using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnShotRust : MonoBehaviour
{
    public float fallSpeed;
    Vector3 home;
    private bool falling = false;
    // Start is called before the first frame update
    void Start()
    {
        home = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (falling)
        {
            transform.Translate(0,-1*fallSpeed*Time.deltaTime, 0);
        }
    }

    public void RustNow()
    {
        falling = true;
    }
    private void OnTriggerEnter (Collider other)
    {
        doDamage ground = other.GetComponent<doDamage>();

        if (ground != null)
        {
            falling = false;
            transform.position = home;
        }
        else
        {
            if (other.gameObject.CompareTag("Player"))
            {
                falling = false;
                transform.position = home;
            }
        }
    }
}
