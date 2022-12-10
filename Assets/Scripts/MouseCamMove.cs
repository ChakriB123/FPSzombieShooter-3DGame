using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCamMove : MonoBehaviour
{

    float MouseX;
    float MouseY;

    public float MouseSensivity = 110f;

    public Transform PlayerBody;

    float Xrotation = 0f;


    // Start is called before the first frame update
    void Start()
    {
       // Cursor.lockState = CursorLockMode.Locked;   
    }

    // Update is called once per frame
    void Update()
    {
         MouseX = Input.GetAxis("Mouse X") * MouseSensivity * Time.deltaTime;   
         MouseY = Input.GetAxis("Mouse Y") * MouseSensivity * Time.deltaTime;

         Xrotation -= MouseY;
         Xrotation  = Mathf.Clamp(Xrotation, -70f, 80f);  

         transform.localRotation = Quaternion.Euler(Xrotation, 0f, 0f);

         PlayerBody.Rotate(Vector3.up * MouseX);
    }
}
