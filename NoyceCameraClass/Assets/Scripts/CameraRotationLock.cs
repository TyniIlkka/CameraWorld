using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotationLock : MonoBehaviour {

    public Transform miniMapCamera;
    public float turnSpeed;
    public CharacterController charController;

    public void Awake()
    {
        charController = GetComponentInParent<CharacterController>();
        miniMapCamera = GetComponent<Transform>();
    }

    public void Update()
    {
        turnSpeed = GetComponentInParent<Character>().turnSpeed;
        if (charController.isGrounded)
        {
            //TurnCamera(Input.GetAxis("Horizontal"));
        }
        TurnCamera(Input.GetAxis("Horizontal"));
    }
    public void TurnCamera(float amount)
    {
        Vector3 rotation = transform.localEulerAngles;
        rotation.y += amount * -turnSpeed * Time.deltaTime;
        transform.localEulerAngles = rotation;
    }

}
