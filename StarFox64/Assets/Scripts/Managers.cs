using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour {
    private void Awake() {
        // the game manager must persist in all the scenes 
        DontDestroyOnLoad(gameObject); 
        // remove cursor 
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; 
    }

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
