using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPoints : MonoBehaviour {
   
    
    [SerializeField] private PlayerScore score;

    public float additive; 
    
    private void OnCollisionEnter(Collision other)
    {
        score.AddScore(additive);
    }
}
