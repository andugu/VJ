using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour {
    private void OnCollisionEnter(Collision other) {
        Debug.Log("COLLISION");
        var destroyable = other.gameObject.GetComponent<Destroyable>();
        Debug.Log(destroyable);
        if (destroyable != null){
            destroyable.Explode(); 
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }
}
