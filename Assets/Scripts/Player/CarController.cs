using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private WheelCollider m_FrontLeft;
    [SerializeField] private WheelCollider m_FrontRight;
    [SerializeField] private WheelCollider m_BackLeft;
    [SerializeField] private WheelCollider m_BackRight;
    [SerializeField] private float Torque;
    [SerializeField] private int Brake = 10000;
    [SerializeField] private float Speed;
    [SerializeField] private float CoefAcceleration = 10f;
    [SerializeField] private float maxAngle;
    [SerializeField] private Rigidbody rb_car;

    public void Update()
    {

        Debug.Log(OVRInput.GetLocalControllerRotation(OVRInput.Controller.LTouch));
        //Acceleration 

          
        m_BackLeft.brakeTorque = 0;
        m_BackRight.brakeTorque = 0;
        m_BackLeft.motorTorque = Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstickVertical") * Torque * CoefAcceleration * Time.deltaTime;
        m_BackRight.motorTorque = Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstickVertical") * Torque * CoefAcceleration * Time.deltaTime;
        rb_car.AddForce(0, 0, m_BackLeft.motorTorque = Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstickVertical") * Torque * CoefAcceleration * Time.deltaTime, ForceMode.VelocityChange);
        //m_BackLeft.motorTorque = 1000 * Torque * CoefAcceleration * Time.deltaTime;
        //m_BackRight.motorTorque = 1000 * Torque * CoefAcceleration * Time.deltaTime;

        
        var postionTouch = OVRInput.GetLocalControllerRotation(OVRInput.Controller.LTouch).y;
        //m_BackLeft.steerAngle =  (maxAngle * postionTouch);
        //m_BackRight.steerAngle =  (maxAngle * postionTouch);

        //rb_car.velocity = new Vector3(0, 0, -1 * (maxAngle * postionTouch));
        m_FrontLeft.steerAngle = -1 * (maxAngle * postionTouch);
        m_FrontRight.steerAngle = -1 * maxAngle * postionTouch;




        //https://www.youtube.com/watch?v=uCM6VBS7tDo
        //Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstickVertical")

    }
}

