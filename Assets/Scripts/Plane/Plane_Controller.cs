using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_Camera : MonoBehaviour{

    public Rigidbody myRigid;
    public float force;
    public Camera FPSCamera;
    public float horizontalSpeed;
    public float verticalSpeed;
    float v;
    float h;

    void Start() {
        myRigid.velocity=this.transform.forward*force;
    }

    void Update() {
        h= horizontalSpeed * Input.GetAxis("Mouse X");
        v= verticalSpeed * Input.GetAxis("Mouse Y");

        transform.Rotate(0,h,0);
        FPSCamera.transform.Rotate(-v,0,0);

        if (Input.GetKey(KeyCode.W)) {
            transform.Rotate(10.0f *Time.deltaTime,0,0);
        } else if (Input.GetKey(KeyCode.S)){
            transform.Rotate(-10.0f *Time.deltaTime,0,0);
        }

        if (Input.GetKey(KeyCode.A)) {
            transform.Rotate(0,0,-10.0f *Time.deltaTime);
        } else if (Input.GetKey(KeyCode.D)){
            transform.Rotate(0,0,10.0f *Time.deltaTime); 
        }
    }
}

