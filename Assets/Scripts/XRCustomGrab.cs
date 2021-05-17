using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRCustomGrab : XRGrabInteractable
{
    [SerializeField] CharacterManager cm;
    public enum Item { Watergun, RCRemote }
    public Item item = Item.Watergun;

    protected override void OnSelectEnter(XRBaseInteractor interactor)
    {
        bool a = true;
        bool leftH = interactor.GetComponent<HandManager>().leftHand;
        if (item.ToString() == "Watergun")
        {
            cm.PickedUpWaterGun(a, leftH);
        }
        else if (item.ToString() == "RCRemote")
        {
            cm.PickedUpRCRemote(a, leftH);
        }


        interactor.GetComponent<HandManager>().HideHand(a);
        base.OnSelectEnter(interactor);
    }
    protected override void OnSelectExit(XRBaseInteractor interactor)
    {
        bool a = false;
        if (item.ToString() == "Watergun")
        {
            cm.PickedUpWaterGun(a, false);
        }
        else if (item.ToString() == "RCRemote")
        {
            cm.PickedUpRCRemote(a, false);
        }
        interactor.GetComponent<HandManager>().HideHand(a);
        base.OnSelectExit(interactor);
    }

}
