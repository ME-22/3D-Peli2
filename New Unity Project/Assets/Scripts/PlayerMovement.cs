using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 20f;

    public float gravity = -9.82f;

    public float jumpHeigt = 3f;

    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeigt * -2f * gravity);
        }

        velocity.y += gravity + Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
