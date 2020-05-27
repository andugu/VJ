using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour {

    public static Transform target;
    public float speed; 
    
    void Update() {
        if(transform.position.z < target.position.z - 100)Destroy(gameObject);
        transform.position = Vector3.Lerp(transform.position, target.position, speed * Time.deltaTime);
    }
}
