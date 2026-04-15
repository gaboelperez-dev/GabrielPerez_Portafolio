using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Axle{
    Front,
    Back

}
public struct Wheel{
    public GameObject model;
    public WheelCollider wheelCollider;
    public Axle axle;
}
[RequireComponent(typeof(Rigidbody))]

public class carcontroler : MonoBehaviour
{
    [SerializeField]
     private float MaxAcceleration = 20f;
     [SerializeField]
    private float turnSensitive = 1f;
    [SerializeField]
    public float maxAngle = 45f;

    private float inputX, inputY;

    private Rigidbody _rb;

    public List<AxleInfo> axleInfos = new List<AxleInfo>();
    // Start is called before the first frame update
    void Start()
    {
        _rb=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate(){
        Move();
    }
    private void Move(){
        foreach(AxleInfo info in axleInfos){
            if(info.isBack){
                info.rightWheel.motorTorque=inputY*MaxAcceleration*500*Time.deltaTime;
                info.leftWheel.motorTorque=inputY*MaxAcceleration*500*Time.deltaTime;
            }
            if(info.isFront){
            var _streerAngle=inputX*turnSensitive*maxAngle;
            info.rightWheel.steerAngle=Mathf.Lerp(info.rightWheel.steerAngle,_streerAngle,0.5f);
            info.leftWheel.steerAngle=Mathf.Lerp(info.leftWheel.steerAngle,_streerAngle,0.5f);
            }
            AnimateWheels(info.rightWheel,info.visualRightWheel);
            AnimateWheels(info.leftWheel,info.visualLeftWheel);
        }
        
    }
    private void AnimateWheels(WheelCollider wheelCollider, Transform wheelTransform){
        Quaternion _rot;
        Vector3 _pos;

        Vector3 rotate = Vector3.zero;

        wheelCollider.GetWorldPose(out _pos, out _rot);
        wheelTransform.transform.rotation=_rot;
    }
}
[System.Serializable]
public class AxleInfo{
    public WheelCollider rightWheel;
    public WheelCollider leftWheel;

    public Transform visualRightWheel;
    public Transform visualLeftWheel;

    public bool isBack;
    public bool isFront;
}
