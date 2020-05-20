using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {


    [SerializeField] private Transform target;
    // Update is called once per frame
    void FixedUpdate() {
        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * 4f); 
        transform.rotation =  Quaternion.Lerp(transform.rotation, target.rotation, Time.deltaTime * 4f); 
    }
}
