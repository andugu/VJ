using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehaviour : MonoBehaviour {

    public string currentLevel; 
    public string nextLevel; 
    
    public void WinGame()
    {
        SceneManager.LoadScene(nextLevel);
    }
    
    public void LoseGame() {
        SceneManager.LoadScene(currentLevel);
    }
   
}
