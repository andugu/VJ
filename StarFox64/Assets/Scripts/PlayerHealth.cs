using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    [SerializeField] private GameObject healthBar;
    public float health;
    private Slider healthSlider;

    private void Start()
    {
        healthSlider = healthBar.GetComponent<Slider>(); 
    }


    void Update()
    {
        healthSlider.value = health; 
    }

    public void reduce(float value)
    {
        health -= value; 
    }

    
    
}
