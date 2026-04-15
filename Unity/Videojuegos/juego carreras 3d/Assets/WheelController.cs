using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WheelController : MonoBehaviour{
    public bool par1=false;
    public bool meta=false;
    public int vuelta=0;
    public bool vueltas=false;

public Rigidbody rb;

    public AudioSource fondo;
    public AudioSource arra;
    public AudioSource des;

    public WheelCollider frontRigth;
    public WheelCollider frontLeft;
    public WheelCollider backRigth;
    public WheelCollider backleft;

    /*public Transform frontRigthTransform;
    public Transform frontLeftTransform;
    public Transform backRigthTransform;
    public Transform backLeftTransform;*/


    private float accelaration = 250;
    private float breakingForce = 350;
    public float maxTurnAngle = 35f;

    private float currentAccelaration = 0f;
    private float currentBreakForce = 0f;
    private float currentTurnAngle = 0f;

    private float ni =0f;
    public bool re=false;
void Start()
    {

        //audio1.Play();
        des.Stop();
        rb = GetComponent<Rigidbody>();
    }
void Update()
    {
       //Debug.Log(currentAccelaration);
       
         if(currentAccelaration!=0){
            Debug.Log("hola");
            if (arra.isPlaying == false)
            {
                arra.Play();
                des.Stop();
            }
        }else if(currentAccelaration==0){
            if (des.isPlaying == false)
            {
                des.Play();
                arra.Stop();
                
            }
        }
       
        
    }
    private void FixedUpdate() {
         if (Input.GetKey("escape")){
        SceneManager.LoadScene(0);
        
       }
       
        //get forward/reverse accelaration from the vertical axis (w and s keys)
        
        currentAccelaration = accelaration * Input.GetAxis("Vertical")*2;
        
        //Debug.Log(currentAccelaration);
        //If we are pressing space bar, give currentBrakingForce a value.
        if (Input.GetKey(KeyCode.Space)||currentAccelaration==0){
            currentBreakForce = breakingForce;
         
            }
        else
            currentBreakForce = 0f;
            
        //Apply acceleration to the front wheels.
        frontRigth.motorTorque = currentAccelaration;
        frontLeft.motorTorque = currentAccelaration;

        frontRigth.brakeTorque = currentBreakForce;
        frontLeft.brakeTorque = currentBreakForce;
        backleft.brakeTorque = currentBreakForce;
        backRigth.brakeTorque = currentBreakForce;

        //Take care of the steering.
        currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");
        frontLeft.steerAngle = currentTurnAngle;
        frontRigth.steerAngle = currentTurnAngle;

        //Update wheel meshes
       /* UpdateWheel(frontLeft, frontLeftTransform);
        UpdateWheel(frontRigth, frontRigthTransform);
        UpdateWheel(backleft, backLeftTransform);
        UpdateWheel(backRigth, backRigthTransform);*/


    }
    

    void UpdateWheel(WheelCollider col, Transform trans) {

        //get wheel collider state.
        Vector3 position;
        Quaternion rotation;
        col.GetWorldPose(out position, out rotation);

        //Set wheel transform state
        trans.position = position;
        trans.rotation = rotation;


    }
  void OnTriggerEnter(Collider collision) {
     if(collision.gameObject.name == "media"){
         par1=true;
     }
      if(collision.gameObject.name == "meta"){
         meta=true;
     } 
     if (par1==true&& meta==true){
         vuelta++;
         par1=false;
         meta=false;
          
        SceneManager.LoadScene(6);
       
         Debug.Log(vuelta);
     }
    }
     void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if(collision.gameObject.tag == "nitro"){
        ni=2;
        rb.velocity = rb.velocity*ni;
        
    }
    if(collision.gameObject.tag == "reloj"){
        re=true;
        
    }
}
}
