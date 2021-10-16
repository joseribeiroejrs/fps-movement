using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    public float limitViewY = 90f;
    float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = getMouseX() * mouseSensitivity * Time.deltaTime;        
        float mouseY = getMouseY() * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -limitViewY, limitViewY);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * mouseX);
    }


    float getMouseX()
	{
        return Input.GetAxis("Mouse X");
	}
    float getMouseY()
    {
        return Input.GetAxis("Mouse Y");
    }
}
