using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour {


    [SerializeField] private float healthValue; 
    
    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth health = other.GetComponent<PlayerHealth>();
        if (health != null)
        {
            health.reduce(healthValue);
        }
    }
}
