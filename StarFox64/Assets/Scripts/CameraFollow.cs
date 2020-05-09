using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {


    [SerializeField] private Transform target;

    public float rotSpeed = 1.5f;

    private float _rotY;
    private Vector3 _offset;
    
	
    // Update is called once per frame
    void LateUpdate() {

    
        transform.position = Vector3.Lerp(transform.position, target.position, 5f * Time.deltaTime);
        Quaternion newRotation = new Quaternion(target.rotation.x, target.rotation.y, Mathf.Clamp(target.rotation.z, -0.1f, 0.1f), target.rotation.w);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, 5f * Time.deltaTime);
    }
}
