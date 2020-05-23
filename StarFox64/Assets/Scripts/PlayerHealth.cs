using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {



    [SerializeField] private GameObject healthBar;
    private float _barWidth;
    private float _initialPos; 
    public float health;

    private void Start() {
        var barScale = healthBar.transform.localScale;
        _barWidth = barScale.x;
        _initialPos = healthBar.transform.position.x; 
    }
    

    void Update() {
        var barScale = healthBar.transform.localScale;
        barScale.x = _barWidth * (health / 100f);
        healthBar.transform.localScale = barScale;
    }
}
