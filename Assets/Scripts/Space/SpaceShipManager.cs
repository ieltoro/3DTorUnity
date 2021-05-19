using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipManager : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public float torque;
    [SerializeField] ParticleSystem fireFX;
    Vector2 inputJoystick;
    float triggerAmount;
    bool spaceShipActive;
    bool leftHand;

    public void SpaceShipActive(bool a, bool leftH)
    {
        spaceShipActive = a;
        leftHand = leftH;
    }

    private void FixedUpdate()
    {
        if (!spaceShipActive)
            return;
        if (leftHand)
        {
            inputJoystick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LTouch);
            triggerAmount = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.LTouch);
            if (OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.LTouch))
            {
                rb.AddForce(transform.forward * -speed / 2.4f, ForceMode.Impulse);
            }
            if (OVRInput.GetUp(OVRInput.Button.Two, OVRInput.Controller.LTouch))
            {
                rb.AddTorque(transform.forward * torque * 0.2f);
            }
        }
        else
        {
            inputJoystick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.RTouch);
            triggerAmount = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.RTouch);
            if (OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.RTouch))
            {
                rb.AddForce(transform.forward * -speed / 1.5f, ForceMode.Impulse);
            }
            if (OVRInput.Get(OVRInput.Button.Two, OVRInput.Controller.RTouch))
            {
                rb.AddTorque(transform.forward * torque * 0.2f); 
            }
        }
        if (triggerAmount > 0.1)
        {
            print("FIRE");
            if(!fireFX.isPlaying)
                 fireFX.Play();
        }
        else
            fireFX.Stop();

        rb.AddForce(transform.forward * triggerAmount * speed, ForceMode.Impulse);
        rb.AddTorque(transform.up * torque * inputJoystick.x);
        rb.AddTorque(transform.right * torque * inputJoystick.y);       
    }

}
