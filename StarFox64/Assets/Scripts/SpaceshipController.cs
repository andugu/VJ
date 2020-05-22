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
    private float _minRotation = -30f;
    private float _maxRotation = 30f;
    private float _breakForce; 

    [SerializeField] private Vector3 direction;
    public float rotSpeed = 60f;
    public float movementSpeed = 20.0f;
    public float gravity = -2.0f;
    public float rotationGravity = 30f;


    private void Start() {
        direction = (direction - transform.position).normalized; 
        _rigidbody = GetComponent<Rigidbody>();
        _breakForce = 1; 
    }

    void Update() {
        // GET INPUT
        _movement = Vector3.zero;
        _horInput = Input.GetAxis("Horizontal");
        _vertInput = Input.GetAxis("Vertical"); // due to game design control is inverted
        // the spaceship movement is simply based on 
        // the pitch, yaw and roll movements 
        Pitch(); // up or down 
        Roll(); // move sideways 
        ApplyBreak(); 
        Forward(); // move forward 
        
    }

    private void ApplyBreak() {
        if (Input.GetKeyDown(KeyCode.F))
        {
            _breakForce = 0.4f; 
            StartCoroutine(WaitToAccelerate());
        }
    }

    private IEnumerator WaitToAccelerate()
    {
        yield return new WaitForSeconds(2);
        _breakForce = 1; 
    }
    
    
    

    private void Pitch() {
        if (_vertInput != 0) {
            transform.position += new Vector3(0, Time.deltaTime * movementSpeed * _vertInput, 0);
            transform.Rotate(new Vector3(1, 0, 0), -_vertInput * rotSpeed * Time.deltaTime);
            Vector3 rot = transform.localRotation.eulerAngles;
            Debug.Log(rot.x);
            rot.x = (rot.x > 180) ? rot.x - 360 : rot.x;
            rot.x = Mathf.Clamp(rot.x, _minRotation, _maxRotation);
            rot.y = 0; 
            transform.localRotation = Quaternion.Euler(rot);
        }
        else
        {
            Quaternion idleQuaternion = transform.rotation;
            idleQuaternion.x = 0; 
            transform.rotation = Quaternion.Lerp(transform.rotation, idleQuaternion, rotationGravity *Time.deltaTime);
        }
    }

    private void Roll() {
        if (_horInput != 0) {
            transform.position += new Vector3(Time.deltaTime * movementSpeed * _horInput, 0, 0); 
            transform.Rotate(new Vector3(0, 0, 1), -_horInput * rotSpeed * Time.deltaTime);
            Vector3 rot = transform.localRotation.eulerAngles;
            rot.z = (rot.z > 180) ? rot.z - 360 : rot.z;
            rot.z = Mathf.Clamp(rot.z, _minRotation, _maxRotation);
            rot.y = 0; 
            transform.localRotation = Quaternion.Euler(rot);
        }
        else {
            Quaternion idleQuaternion = transform.rotation;
            idleQuaternion.z = 0; 
            transform.rotation = Quaternion.Lerp(transform.rotation, idleQuaternion, rotationGravity *Time.deltaTime);
        }
    }
    

    

    private void Forward() {
        transform.position += direction * (_breakForce * movementSpeed * Time.deltaTime); 
    }


}
