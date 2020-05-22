using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(TextSelector))]
public class OptionsMenuController : MonoBehaviour {



    [SerializeField] private MenuManager _manager;
    private TextSelector _selector; 

    private void Start() {
        _selector = GetComponent<TextSelector>(); 
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            var pos = _selector.GetSelectedScene();
            MenuManager.MenuState state = MenuManager.MenuState.CreditsMenu;
            if (pos == 0) state = MenuManager.MenuState.Gaming;
            if (pos == 1) state =  MenuManager.MenuState.LevelsMenu;
            if (pos == 2) state =  MenuManager.MenuState.InstructionsMenu; 
             
            _manager.ChangeScene(state);
        }
              
    }
}
