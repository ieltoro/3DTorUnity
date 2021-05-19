using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] XRController teleportRay;
    [SerializeField] InputHelpers.Button teleButton;
    [Header("Items")]
    [SerializeField] WaterGunManager waterG;
    [SerializeField] RCCarManager rcm;
    [SerializeField] SpaceShipManager space;
    [SerializeField] GravityChange gravity;
    [SerializeField] GameObject teleportReticle;
    [SerializeField] SnapTurnProvider turn;
    public bool CanMove = true;

    public void PickedUpRCRemote(bool a, bool leftHand)
    {
        rcm.leftHandHolding = leftHand;
        rcm.enabled = a;
        rcm.active = a;
        if (leftHand)
        {
            turn.enabled = !a;
        }
        if (!leftHand)
        {
            CanMove = !a;
        }
    }
    public void PickedUpWaterGun(bool a, bool leftHand)
    {
        waterG.ActivateGun(a, leftHand);
        if (leftHand)
        {
            turn.enabled = !a;
        }
        if(!leftHand)
        {
            CanMove = !a;
        }
    }
    public void PickedUpSpaceShip(bool a, bool leftHand)
    {
        space.SpaceShipActive(a, leftHand);
        gravity.ChangeGravity(a);
        if(leftHand)
        {
            turn.enabled = !a;
        }
        if (!leftHand)
        {
            CanMove = !a;
        }
    }
    private void Update()
    {
        if(CanMove)
        {
            bool b = IsTeleActive();
            teleportRay.gameObject.SetActive(b);
            teleportRay.gameObject.GetComponent<LineRenderer>().enabled = b;
            teleportRay.gameObject.GetComponent<XRInteractorLineVisual>().enabled = b;
            teleportReticle.SetActive(b);
        }
    }

    bool IsTeleActive()
    {
        InputHelpers.IsPressed(teleportRay.inputDevice, teleButton, out bool isUsing, 0.1f);
        return isUsing;
    }
}
