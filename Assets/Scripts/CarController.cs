using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool steering; // checks if this wheel is supposed to apply a steer angle
    public bool motor; // checks if this wheel is attached to the motor
}

public class CarController : MonoBehaviour
{
    public List<AxleInfo> axleInfos; // the information about each indivual axle
    public float lerpWheel, lerpMin, lerpMax, lerpSteering; // lerp for smooth wheel movement
    public float maxMotorTorque; // maximum torque the motor can apply to a wheel
    public float maxSteeringAngle; //maximum steer angle the wheel can have

    public InputAction carControll; //Used for the new unity input system

    //Makes the wheels mirror the wheel colliders position and rotation
    public void ApplyLocalPositionToVisuals(WheelCollider collider)
    {
        if (collider.transform.childCount == 0)
        {
            return;
        }

        Transform visualWheel = collider.transform.GetChild(0);

        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }
    private void OnEnable()
    {
        carControll.Enable();
    }
    public void FixedUpdate()
    {
        //A lerp used for steering and also helps with implementing unity's new input system
        lerpSteering = Mathf.Clamp(lerpSteering, 0, 1);
        lerpWheel = Mathf.Lerp(lerpMin, lerpMax, lerpSteering);
        lerpSteering += carControll.ReadValue<Vector2>().x * 0.1f;

        float motor = maxMotorTorque * carControll.ReadValue<Vector2>().y;
        float steering = maxSteeringAngle * lerpWheel;

        if (carControll.ReadValue<Vector2>().x == 0f)
        {
            lerpSteering += lerpWheel / -10;
        }

        //float motor = maxMotorTorque * Input.GetAxis("Vertical");
        //float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

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
        ApplyLocalPositionToVisuals(axleInfo.leftWheel);
        ApplyLocalPositionToVisuals(axleInfo.rightWheel);
        }
    }
}