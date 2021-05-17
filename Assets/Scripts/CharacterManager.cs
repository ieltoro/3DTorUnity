using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] GameObject rcRemoteObj;
    [SerializeField] XRController teleportRay;
    [SerializeField] InputHelpers.Button teleButton;
    [Header("Items")]
    [SerializeField] WaterGunManager waterG;
    [SerializeField] RCCarManager rcm;
    public bool CanMove = true;

    public void PickedUpRCRemote(bool a, bool leftHand)
    {
        rcm.leftHandHolding = leftHand;
        rcm.enabled = a;
        rcm.active = a;
    }
    public void PickedUpWaterGun(bool a, bool leftHand)
    {
        print("PickedUpWaterGun");
        waterG.ActivateGun(true, leftHand);
    }
    private void Update()
    {
        if(CanMove)
            teleportRay.gameObject.SetActive(IfTeleActive());
        
    }
    bool IfTeleActive()
    {
        InputHelpers.IsPressed(teleportRay.inputDevice, teleButton, out bool isUsing, 0.1f);
        return isUsing;
    }
}
