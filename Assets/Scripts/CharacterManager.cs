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
    [SerializeField] SpaceShipManager space;
    public bool CanMove = true;

    public void PickedUpRCRemote(bool a, bool leftHand)
    {
        rcm.leftHandHolding = leftHand;
        rcm.enabled = a;
        rcm.active = a;
    }
    public void PickedUpWaterGun(bool a, bool leftHand)
    {
        waterG.ActivateGun(a, leftHand);
    }
    public void PickedUpSpaceShip(bool a, bool leftHand)
    {
        space.SpaceShipActive(a, leftHand);
    }
    private void Update()
    {
        if(CanMove)
        {
            if(IsTeleActive())
            {
                teleportRay.gameObject.GetComponent<LineRenderer>().enabled = false;
                teleportRay.gameObject.GetComponent<XRInteractorLineVisual>().enabled = false;
            }
        }
            teleportRay.gameObject.SetActive(IsTeleActive());
        
    }
    bool IsTeleActive()
    {
        InputHelpers.IsPressed(teleportRay.inputDevice, teleButton, out bool isUsing, 0.2f);
        return isUsing;
    }
}
