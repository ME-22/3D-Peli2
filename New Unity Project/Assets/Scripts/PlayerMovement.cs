using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public Transform groundCheck;

    public float groundDistance = 0.4f;

    public LayerMask GroundMask;

    public float speed = 20f;

    public float gravity = -9.82f;

    public float JumpHeigt = 3f;

    private Vector3 velocity = Vector3.zero;

    private bool isGrounded;

    private bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!canMove){
            return;
        }
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, GroundMask);


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Move(x,z);

        Jump();

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    public void Move(float x, float z){

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
    }

    public void Jump() {

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(JumpHeigt * -2f * gravity);
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundCheck.position, groundDistance);
    }

}
