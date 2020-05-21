using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainMenuController : MonoBehaviour {


    [SerializeField] private MenuManager _manager; 
    

    // Update is called once per frame
    void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) _manager.ChangeScene(MenuManager.MenuState.MenuSelector);
    }
}
