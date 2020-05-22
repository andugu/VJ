using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackAndShoot : MonoBehaviour
{
    [SerializeField] private GameObject laser;
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject origin;
    [SerializeField] private Vector3 predictionPos; 
    public float force = 20.0f;
    private float timer = 0.0f;
    // Start is called before the first frame update
    void Start(){}

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime *100;
        if (timer >= 3.0f){
        	// Shoot spaceship
        	// instantiate a new laser at current position
            var outLaser = Instantiate(laser, origin.transform.position, Quaternion.identity);
            // must have a rigid body
            // apply a force to the laser
            var rigidBody =  outLaser.GetComponent<Rigidbody>();
            // Shoot to spaceship    
            var targetPos = target.transform.position + predictionPos;
            var direction = (targetPos - origin.transform.position).normalized;
            rigidBody.AddForce(direction * force);
            timer = 0.0f;
        }
    }
}
