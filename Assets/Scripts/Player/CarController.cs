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

    public void Update()
    {

        Debug.Log(OVRInput.GetLocalControllerRotation(OVRInput.Controller.LTouch));
        Debug.Log(Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstickVertical") * Torque * CoefAcceleration * Time.deltaTime);

        //Acceleration 

        if(Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstickVertical") > 0)
          
        m_BackLeft.brakeTorque = 0;
        m_BackRight.brakeTorque = 0;
        m_BackLeft.motorTorque = Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstickVertical") * Torque * CoefAcceleration * Time.deltaTime;
        m_BackRight.motorTorque = 1000 +  Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstickVertical") * Torque * CoefAcceleration * Time.deltaTime;

        if(Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstickVertical") <= 0)
        {
            m_BackLeft.brakeTorque = 0;
            m_BackRight.brakeTorque = 0;
            m_BackLeft.motorTorque = Brake* CoefAcceleration * Time.deltaTime;
            m_BackRight.motorTorque = Brake * Torque * CoefAcceleration * Time.deltaTime;
        }



        //Deceleration


            //https://www.youtube.com/watch?v=uCM6VBS7tDo
            //Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstickVertical")

    }
}

