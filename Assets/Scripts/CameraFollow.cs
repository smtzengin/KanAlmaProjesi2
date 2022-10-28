using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;
    
    float xRotation;
    float yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        //yRotation += PlayerController.instance.gameObject.transform.rotation.y;
        //xRotation -= PlayerController.instance.gameObject.transform.rotation.x;

        //xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        //orientation.rotation = Quaternion.Euler(0, yRotation, 0);

    }
}
