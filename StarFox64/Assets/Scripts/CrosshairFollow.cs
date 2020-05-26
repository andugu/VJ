using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairFollow : MonoBehaviour{


    public float speed = 10f;
    public float returnSpeed = 10f;
    private Vector3 initialPos;


    void Start(){
      initialPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update(){
        float vertInput = -Input.GetAxis("Vertical");
        float horInput = Input.GetAxis("Horizontal");
        Vector3 pos = transform.localPosition;
        if(horInput != 0){
            pos.x += horInput * speed * Time.deltaTime;
        }
        else{
          //pos = Vector3.Lerp(pos, new Vector3(initialPos.x, pos.y, pos.z), returnSpeed * Time.deltaTime);
        }
        if(vertInput != 0){
            pos.y += vertInput * speed * Time.deltaTime;
        }
        else{
            pos = Vector3.Lerp(pos, new Vector3(pos.x, initialPos.y, pos.z), returnSpeed * Time.deltaTime);
        }
        transform.localPosition = pos;


    }
}
