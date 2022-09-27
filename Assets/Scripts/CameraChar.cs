using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChar : MonoBehaviour
{
    public float mouseLook = 100f;
    public Transform Target, Player;
    float mouseX, mouseY;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        TryThis();
    }

    void TryThis()
    {
        //float mouseX = Input.GetAxis("Mouse X") * mouseLook * Time.deltaTime;
        //ourPlayer.Rotate(Vector3.up * mouseX);

        mouseX += Input.GetAxis("Mouse X") * mouseLook;
        mouseY -= Input.GetAxis("Mouse Y") * mouseLook;
        //mouseY = Mathf.Clamp(mouseY, -35, 60);
        mouseY = Mathf.Clamp(mouseY, -90, 60);

        transform.LookAt(Target);

        Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        Player.rotation = Quaternion.Euler(0, mouseX, 0);
    }
}
