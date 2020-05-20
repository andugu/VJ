using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SpaceshipController : MonoBehaviour {


    private float _horInput;
    private float _vertInput;
    private Vector3 _movement;
    private Rigidbody _rigidbody;

    public float maxRotation = 15f; 
    public float rotSpeed = 60f;
    public float movementSpeed = 20.0f;
    public float gravity = -2.0f;
    public float rotationGravity = 30f;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>(); 
    }

    void Update() {
        // GET INPUT
        _movement = Vector3.zero;
        _horInput = -Input.GetAxis("Horizontal");
        _vertInput = Input.GetAxis("Vertical"); // due to game design control is inverted
        // the spaceship movement is simply based on 
        // the pitch, yaw and roll movements 
        Pitch(); // up or down 
        Roll(); // move sideways 
        Yaw(); // change current direction 
    
        Forward(); // move forward 
        
    }
    
    
    

    private void Pitch() {
        if (_vertInput != 0) {
            transform.Rotate(new Vector3(1, 0, 0), _vertInput * rotSpeed * Time.deltaTime);
            float angle = transform.eulerAngles.x;
            float maxAngle = 360 - maxRotation; 
            
            if (angle > maxRotation && angle < maxAngle)
            {
                if (angle - maxRotation < maxAngle - angle) angle = maxRotation;
                else angle = maxAngle;
                transform.eulerAngles = new Vector3(angle, transform.eulerAngles.y, transform.eulerAngles.z);
            }
            //transform.eulerAngles = new Vector3(Mathf.Clamp(transform.eulerAngles.x, -90, 90),
            //   transform.eulerAngles.y, transform.eulerAngles.z );Mathf.Clamp(transform.eulerAngles.x, -90, 90);
        }
    }

    private void Roll() {
        if (_horInput != 0)
        {
            transform.Rotate(new Vector3(0, 0, 1), _horInput * rotSpeed * Time.deltaTime);  
            float angle = transform.eulerAngles.z;
            float maxAngle = 360 - maxRotation;
            if (angle > maxRotation && angle < maxAngle)
            {
                if (angle - maxRotation < maxAngle - angle) angle = maxRotation;
                else angle = maxAngle;
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, angle);
            }
        }
    }


    private void Yaw() {
        if (_horInput != 0)
                {
                    transform.Rotate(new Vector3(0, 1, 0), -_horInput * rotSpeed * Time.deltaTime);  
                    float angle = transform.eulerAngles.y;
                    float maxAngle = 360 - maxRotation;
                    if (angle > maxRotation && angle < maxAngle)
                    {
                        if (angle - maxRotation < maxAngle - angle) angle = maxRotation;
                        else angle = maxAngle;
                        transform.eulerAngles = new Vector3(transform.eulerAngles.x, angle, transform.eulerAngles.z);
                    }
                }
    }

    private void Forward()
    {
        _movement = transform.forward * movementSpeed; 
        Vector3 moveDirection = transform.TransformDirection(_movement);
        _rigidbody.velocity = moveDirection; 
    }


}
