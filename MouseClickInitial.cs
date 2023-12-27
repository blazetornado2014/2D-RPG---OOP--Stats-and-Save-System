using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public float mouseSensitivity = 100.0f;
    public Transform playerBody;
    float xRotate = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotate -= mouseY;

        //Clamp to 180 so player can't look behind them vertically
        xRotate = Mathf.Clamp(xRotate, -90.0f, 90.0f);

        //Use this method when clamping to rotate
        transform.localRotation = Quaternion.Euler(xRotate, 0.0f, 0.0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}