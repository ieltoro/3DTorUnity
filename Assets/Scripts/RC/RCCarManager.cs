using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class RCCarManager : MonoBehaviour
{
    public bool active;
    Vector2 inputJoystick;
    float steeringAngle;
    public WheelCollider frWC, flWC, rrWC, rlWC;
    public Transform frWT, flWT, rrWT, rlWT;
    [SerializeField] float maxSteering;
    [SerializeField] float motorPower, holdDown;
    public bool leftHandHolding;
    bool reverse;
    float startTime;
    public int wDrive;

    void Update()
    {
        if(active)
        {
            if(leftHandHolding)
            {
                inputJoystick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LTouch);
                inputJoystick.y = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.LTouch);
                if (OVRInput.GetUp(OVRInput.Button.One, OVRInput.Controller.LTouch))
                {
                    reverse = true;
                }
                if (OVRInput.GetUp(OVRInput.Button.Two, OVRInput.Controller.LTouch))
                {
                    reverse = false;
                }
            }
            if (!leftHandHolding)
            {
                inputJoystick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.RTouch);
                inputJoystick.y = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.RTouch);
                if (OVRInput.GetUp(OVRInput.Button.One, OVRInput.Controller.RTouch))
                {
                    reverse = true;
                }
                if (OVRInput.GetUp(OVRInput.Button.Two, OVRInput.Controller.RTouch))
                {
                    reverse = false;
                }
                if (OVRInput.GetDown(OVRInput.Button.SecondaryThumbstick))
                {
                    print("Pressing down");
                    startTime = Time.time;
                }
                if (OVRInput.Get(OVRInput.Button.SecondaryThumbstick))
                {
                    if(startTime + holdDown >= Time.time)
                    {
                        startTime = Time.time;
                        ResetCar();
                    }
                }
            }
        }
        //else
        //{
        //    inputJoystick = new Vector2(0, 0);
        //}
    }

    private void FixedUpdate()
    {
        UpdateSteering();
        UpdateAcceleration();
        UpdateSteering();
        UpdateWheel();
    }
    void UpdateSteering()
    {
        steeringAngle = maxSteering * inputJoystick.x;
        frWC.steerAngle = steeringAngle;
        flWC.steerAngle = steeringAngle;
        rrWC.steerAngle = -steeringAngle/3;
        rlWC.steerAngle = -steeringAngle/3;
    }
    void UpdateAcceleration()
    {
        if (reverse)
        {
            if(wDrive == 0)
            {
                rrWC.motorTorque = inputJoystick.y * -motorPower;
                rlWC.motorTorque = inputJoystick.y * -motorPower;
                frWC.motorTorque = inputJoystick.y * -motorPower;
                flWC.motorTorque = inputJoystick.y * -motorPower;
            }
            if (wDrive == 1) // Front
            {

                frWC.motorTorque = inputJoystick.y * -motorPower;
                flWC.motorTorque = inputJoystick.y * -motorPower;
            }
            if (wDrive == 2) // Back
            {

                rrWC.motorTorque = inputJoystick.y * -motorPower;
                rlWC.motorTorque = inputJoystick.y * -motorPower;
            }

        }
        else
        {
            if (wDrive == 0)
            {
                rrWC.motorTorque = inputJoystick.y * motorPower;
                rlWC.motorTorque = inputJoystick.y * motorPower;
                frWC.motorTorque = inputJoystick.y * motorPower;
                flWC.motorTorque = inputJoystick.y * motorPower;
            }
            if (wDrive == 1) // Front
            {

                frWC.motorTorque = inputJoystick.y * motorPower;
                flWC.motorTorque = inputJoystick.y * motorPower;
            }
            if (wDrive == 2) // Back
            {

                rrWC.motorTorque = inputJoystick.y * motorPower;
                rlWC.motorTorque = inputJoystick.y * motorPower;
            }
        }

    }
    void UpdateWheel()
    {
        UpdateWheelPos(frWC, frWT);
        UpdateWheelPos(flWC, flWT);
        UpdateWheelPos(rrWC, rrWT);
        UpdateWheelPos(rlWC, rlWT);
    }
    void UpdateWheelPos(WheelCollider wc, Transform tr)
    {
        Vector3 pos = tr.position;
        Quaternion rot = tr.rotation;

        wc.GetWorldPose(out pos, out rot);

        //tr.position = pos;
        tr.rotation = rot;
    }

    public void ResetCar()
    {
        print("Reset");
    }
}
