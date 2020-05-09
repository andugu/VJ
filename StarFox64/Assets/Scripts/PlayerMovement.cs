using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    

    private CharacterController _controller;
    
    public float rotSpeed = 60f;
    public float movementSpeed = 20.0f;
    public float gravity = -2.0f;
    public float rotationGravity = 30f;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    void Update() {
        // GET INPUT
        Vector3 movement = Vector3.zero;
        float horInput = Input.GetAxis("Horizontal");
        float vertInput = -Input.GetAxis("Vertical"); // due to game design control is inverted
        // IF HORIZONTAL OR VERTICAL => MOVE
        if (horInput != 0 || vertInput != 0) {
            movement.x = horInput * movementSpeed;
            movement.y = vertInput * movementSpeed;
            movement = Vector3.ClampMagnitude(movement, movementSpeed);
            // rotate horizontally, tile the aircraft to the side
            float horRotationAngle = -horInput * Time.deltaTime * rotSpeed;
            float vertRotationAngle = -vertInput * Time.deltaTime * rotSpeed; 
            transform.Rotate(vertRotationAngle, 0, horRotationAngle);
        
            // clamp rotation 
            Quaternion tmp = transform.rotation;
            tmp.x = Mathf.Clamp(tmp.x, -0.20f, 0.20f);
            tmp.z = Mathf.Clamp(tmp.z, -0.30f, 0.30f);
            transform.rotation = new Quaternion(tmp.x, tmp.y, tmp.z, tmp.w);
        }

        // IF NOT HORIZONTAL INPUT => RETURN TO CENTER 
        if (horInput == 0) {
            transform.rotation = Quaternion.Lerp(transform.rotation, 
                new Quaternion(transform.rotation.x, transform.rotation.y, 0, transform.rotation.w),  
                Time.deltaTime * rotationGravity);
        }
        
        // IF NOT VERTICAL INPUT => APPLY DOWN_FORCE 
        if (vertInput == 0) {
            movement.y = gravity; 
            transform.rotation = Quaternion.Lerp(transform.rotation, 
                new Quaternion(0, transform.rotation.y, transform.rotation.z, transform.rotation.w),  
                Time.deltaTime * rotationGravity);
        }

        // ALWAYS KEEP MOVING FORWARD
        movement += transform.forward * movementSpeed;
        // APPLY DELTA TIME 
        movement *= Time.deltaTime;
        // MOVE PLAYER 
        _controller.Move(movement);

    }
    
 
}
