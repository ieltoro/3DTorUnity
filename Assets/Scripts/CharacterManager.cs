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
    public bool CanMove = true;

    public void PickedUpRCRemote()
    {

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
