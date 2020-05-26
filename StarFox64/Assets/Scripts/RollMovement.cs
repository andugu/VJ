﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollMovement : MonoBehaviour {


    public float rollSpeed; 
    
    private KeyCode rollKey = KeyCode.R;
    
    
    void LateUpdate() {
        if (Input.GetKeyDown(rollKey)) {
            transform.Rotate(new Vector3(0, 0, 1), 6000);
        }
    }
}
