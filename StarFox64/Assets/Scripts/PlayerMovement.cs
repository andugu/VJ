using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {


    [SerializeField] private Transform target;

    private CharacterController _controller;
    
    public float rotSpeed = 15.0f;
    public float movementSpeed = 15.0f;
    public float gravity = -2.0f; 

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    void Update() {

        Vector3 movement = Vector3.zero;
        float horInput = Input.GetAxis("Horizontal");
        float vertInput = Input.GetAxis("Vertical");
        if (horInput != 0 || vertInput != 0)
        {
            movement.x = horInput * movementSpeed;
            movement.y = vertInput * movementSpeed;
            movement = Vector3.ClampMagnitude(movement, movementSpeed);
            Quaternion tmp = target.rotation;
            target.eulerAngles = new Vector3(0, target.eulerAngles.y, 0);
            movement = target.TransformDirection(movement);
            target.rotation = tmp;
            Quaternion direction = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Lerp(transform.rotation, direction, rotSpeed * Time.deltaTime);
        }

        if (vertInput == 0)
        {
            movement.y = gravity; 
        }
        Debug.Log(Vector3.forward);
        movement *= Time.deltaTime;
        _controller.Move(movement);


    }
}
