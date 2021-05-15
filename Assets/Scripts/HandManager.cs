using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandManager : MonoBehaviour
{
    public enum Hand { Left, Right }
    public Hand hand = Hand.Left;
    InputDevice targetDevice;
    Vector2 inputJoystick;
    [SerializeField] Animator handAnim, indexAnim, thumbAnim;
    [SerializeField] FingerPointer fp;
    [SerializeField] GameObject handObj;
    public GameObject objHolding;
    [SerializeField] float triggerValue, gripValue;
    public CharacterManager cm;
    void Start()
    {
        if (hand.ToString() == "Left")
        {
            List<InputDevice> devices = new List<InputDevice>();
            InputDeviceCharacteristics leftcontroller = InputDeviceCharacteristics.Left | InputDeviceCharacteristics.Controller;
            InputDevices.GetDevicesWithCharacteristics(leftcontroller, devices);
            print(devices[0].name);
            if (devices.Count > 0)
            {
                targetDevice = devices[0];
            }
        }
        else
        {
            List<InputDevice> devices = new List<InputDevice>();
            InputDeviceCharacteristics rightcontroller = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
            InputDevices.GetDevicesWithCharacteristics(rightcontroller, devices);
            print(devices[0].name);
            if (devices.Count > 0)
            {
                targetDevice = devices[0];
            }
        }
        print("hand.ToString() = " + hand.ToString());

    }

    void Update()
    {
        #region Oculus Touch
        if(hand.ToString() == "Left")
        {
            triggerValue = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.LTouch);
            gripValue = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.LTouch);
            handAnim.SetFloat("GripAmount", gripValue);
            indexAnim.SetFloat("GripAmount", gripValue);
            thumbAnim.SetFloat("GripAmount", gripValue);
            if (gripValue > 0.8f)
            {
                if (!OVRInput.Get(OVRInput.Touch.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
                {
                    indexAnim.SetBool("Touching", false);
                    fp.pointing = true;
                }
                else
                {
                    indexAnim.SetBool("Touching", true);
                    fp.pointing = false;
                }

            }
            else
            {
                indexAnim.SetBool("Touching", true);
                fp.pointing = false;
            }
            if (!OVRInput.Get(OVRInput.Touch.PrimaryThumbstick, OVRInput.Controller.LTouch))
            {
                thumbAnim.SetBool("Touching", false);
            }
            else
            {
                thumbAnim.SetBool("Touching", true);
            }
            if (OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.LTouch))
            {
                print("Pressed 1");
            }
            if (OVRInput.Get(OVRInput.Button.Two, OVRInput.Controller.LTouch))
            {
                print("Pressed 2");
            }
        }
        else
        {
            gripValue = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.RTouch);
            triggerValue = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.RTouch);
            handAnim.SetFloat("GripAmount", gripValue);
            indexAnim.SetFloat("GripAmount", gripValue);
            thumbAnim.SetFloat("GripAmount", gripValue);
            if (gripValue > 0.8f)
            {
                if (!OVRInput.Get(OVRInput.Touch.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
                {
                    indexAnim.SetBool("Touching", false);
                    fp.pointing = true;
                }
                else
                {
                    indexAnim.SetBool("Touching", true);
                    fp.pointing = false;
                }

            }
            else
            {
                indexAnim.SetBool("Touching", true);
                fp.pointing = false;
            }
            if (!OVRInput.Get(OVRInput.Touch.PrimaryThumbstick, OVRInput.Controller.RTouch))
            {
                thumbAnim.SetBool("Touching", false);
            }
            else
            {
                thumbAnim.SetBool("Touching", true);
            }
            if (OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.RTouch))
            {
                print("Pressed 1");
            }
            if (OVRInput.Get(OVRInput.Button.Two, OVRInput.Controller.RTouch))
            {
                print("Pressed 2");
            }
        }
        #endregion
    }

    public void VibrateController()
    {
        if (hand.ToString() == "Left")
        {
            OVRInput.SetControllerVibration(1f, 1f, OVRInput.Controller.LTouch);
        }
        else
        {
            OVRInput.SetControllerVibration(0.01f, 0.02f, OVRInput.Controller.RTouch);
        }
    }
    public void HideHand(bool answer)
    {
        handObj.SetActive(!answer);
    }

    #region RC car

    [SerializeField] RCCarManager rcm;
    public void DisplayRemoteController(bool answer)
    {
        
        cm.PickedUpRCRemote();
        rcm.enabled = answer;
        if (hand.ToString() == "Left")
            rcm.leftHandHolding = true;
        else
            rcm.leftHandHolding = false;
        rcm.active = answer;
    }

    #endregion
}
