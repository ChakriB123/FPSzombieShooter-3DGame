using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovment : MonoBehaviour
{
    float X;
    float Z;

    public CharacterController characterControllerObj;

    public float g_Speed = 12f;
    public float g_Gravity = -9.81f;
    public float JumpHeight = 3f;



    public Transform GroundCheck;
    public float GroundDistance = 0.4f;
    public LayerMask GroundMask;


    Vector3 velocity;
    bool isGrounded;
    
    void Update()
    {

        isGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }


        X = Input.GetAxis("Horizontal");
        Z = Input.GetAxis("Vertical");

        Vector3 Movement = transform.right * X + transform.forward * Z;


        characterControllerObj.Move(Movement * g_Speed * Time.deltaTime);  

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(JumpHeight * -2f * g_Gravity);
        }

        velocity.y += g_Gravity * Time.deltaTime;

        characterControllerObj.Move(velocity * Time.deltaTime);
    }
}
