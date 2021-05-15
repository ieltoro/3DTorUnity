using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRCustomGrab : XRGrabInteractable
{

    protected override void OnSelectEnter(XRBaseInteractor interactor)
    {
        interactor.GetComponent<HandManager>().HideHand(true);
        base.OnSelectEnter(interactor);
    }
    protected override void OnSelectExit(XRBaseInteractor interactor)
    {
        interactor.GetComponent<HandManager>().HideHand(false);
        base.OnSelectExit(interactor);
    }

}
