using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    public float speed = 10f;
    private float gravity = -9.81f;
    public Transform sueloCheck;
    public float sphereRadius = 0.3f;
    public LayerMask groundMask;
    bool isGrounded;
    Vector3 velocity;
    public float jumpHeight = 3f;
    void Update()
    {
        isGrounded = Physics.CheckSphere(sueloCheck.position,sphereRadius,groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");  
        float z = Input.GetAxis("Vertical");
        //Estamos diciendo que un vector unitario lo estamos multiplicando horizontalmente o verticalmente.
        Vector3 move = transform.right * x + transform.forward * z;
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(move * speed * Time.deltaTime);
        characterController.Move(velocity * Time.deltaTime);
    }
}
