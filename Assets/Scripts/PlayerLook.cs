using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    //Camera Move Settings
    public float mouseSensitivity;
    public Camera playerCam;

    //Camera Bob Settings
    public float camBobAmplifier, camBobSpeed;

    //Private Placeholder Variables
    float yRotation = 0, offset = 0;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; 
    }

    private void Update()
    {
        CameraLook();
        CameraBob();
    }

    void CameraLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        yRotation -= mouseY;
        yRotation = Mathf.Clamp(yRotation, -90f, 90f);

        transform.Rotate(Vector3.up * mouseX);
        playerCam.transform.localRotation = Quaternion.Euler(yRotation, 0f, 0f);
    }
    void CameraBob()
    {
        offset += camBobSpeed;

        playerCam.transform.localPosition += new Vector3(0, Mathf.Cos(offset) * camBobAmplifier, 0);
    }
}
