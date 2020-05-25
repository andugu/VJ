using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrangaController : MonoBehaviour {


    [SerializeField] private GameObject target; 
    
    public float speed = 10f;

    void Update() {
          transform.position += new Vector3(0, 0, -speed * Time.deltaTime);      
    }
}
