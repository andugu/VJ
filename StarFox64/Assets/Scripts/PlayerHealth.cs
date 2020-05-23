using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {



    [SerializeField] private GameObject healthBar; 
    public float health; 
    
    
    void Update() {
        var barScale = healthBar.transform.localScale;
        barScale.x = health;
        healthBar.transform.localScale = barScale;
    }
}
