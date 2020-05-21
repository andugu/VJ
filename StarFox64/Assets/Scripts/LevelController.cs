using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(TextSelector))]
public class LevelController : MonoBehaviour {

    [SerializeField] private MenuManager _manager; 
   
    private TextSelector _selector; 

    private void Start() {
        _selector = GetComponent<TextSelector>(); 
    }
    
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var pos = _selector.GetSelectedScene();
            if (pos == 2) _manager.ChangeScene(MenuManager.MenuState.MenuSelector);
            else {
                if (pos == 0) _manager.SetLevel(1);
                if (pos == 1) _manager.SetLevel(2);
                _manager.ChangeScene(MenuManager.MenuState.Gaming);
            }
            
        }
    }
}
