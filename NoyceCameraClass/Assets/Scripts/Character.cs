using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    public float moveSpeed = 70.0f;
    public float turnSpeed = 100.0f;
    public float jumpSpeed = 80.0f;
    public float gravity = 200.0f;
    private Vector3 moveDirection = Vector3.zero;

    public void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded )
        {
            moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection = moveDirection * moveSpeed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

            //Turn(Input.GetAxis("Horizontal"));

        }
        Turn(Input.GetAxis("Horizontal"));
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

    public void Turn(float amount)
    {
        Vector3 rotation = transform.localEulerAngles;
        rotation.y += amount * turnSpeed * Time.deltaTime;
        transform.localEulerAngles = rotation;
    }
}
