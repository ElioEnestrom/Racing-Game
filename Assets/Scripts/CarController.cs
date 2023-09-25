using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarController : MonoBehaviour
{
    public List<AxleInfo> axleInfos; // the information about each indivual axle
    public float maxMotorTorque; // maximum torque the motor can apply to a wheel
    public float maxSteeringAngle; //maximum steer angle the wheel can have

    public InputAction carControll;

    // an OnEnable and OnDisable function for the input system to work
    private void OnEnable()
    {
        carControll.Enable();
    }

    private void OnDisable()
    {
        carControll.Disable();
    }
    public void FixedUpdate()
    {
        float motor = maxMotorTorque * carControll.ReadValue<Vector2>().y;
        float steering = maxSteeringAngle * carControll.ReadValue<Vector2>().x;

        foreach (AxleInfo axleInfo in axleInfos)
        {
            //Handles the steering
            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
        }
    }
}
[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool steering; // checks if this wheel is supposed to apply a steer angle
    public bool motor; // checks if this wheel is attached to the motor
}
