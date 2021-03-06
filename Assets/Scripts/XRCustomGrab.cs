using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRCustomGrab : XRGrabInteractable
{
    [SerializeField] CharacterManager cm;
    public enum Item { None, Watergun, RCRemote, ColorBall, SpaceShip, Sword}
    public Item item = Item.None;

    protected override void OnSelectEnter(XRBaseInteractor interactor)
    {
        bool a = true;
        print(interactor.transform.name);

        if (interactor.transform.name == "Left Hand")
        {
            interactor.GetComponent<HandManager>().HideHand(true);
            if (item.ToString() == "Watergun")
            {
                cm.PickedUpWaterGun(a, true);
            }
            else if (item.ToString() == "RCRemote")
            {
                cm.PickedUpRCRemote(a, true);
            }
            else if (item.ToString() == "ColorBall")
            {
                GetComponent<BallCollision>().SetActive();
            }
            else if (item.ToString() == "SpaceShip")
            {
                cm.PickedUpSpaceShip(a, true);
            }
        }
        if (interactor.transform.name == "Right Hand")
        {
            interactor.GetComponent<HandManager>().HideHand(true);
            if (item.ToString() == "Watergun")
            {
                cm.PickedUpWaterGun(a, false);
            }
            else if (item.ToString() == "RCRemote")
            {
                cm.PickedUpRCRemote(a, false);
            }
            else if (item.ToString() == "ColorBall")
            {
                GetComponent<BallCollision>().SetActive();
            }
            else if (item.ToString() == "SpaceShip")
            {
                cm.PickedUpSpaceShip(a, false);
            }
        }

        
        base.OnSelectEnter(interactor);
    }
    protected override void OnSelectExit(XRBaseInteractor interactor)
    {
        bool a = false;

        if (interactor.transform.name == "Left Hand")
        {
            interactor.GetComponent<HandManager>().HideHand(false);
            if (item.ToString() == "Watergun")
            {
                cm.PickedUpWaterGun(a, true);
            }
            else if (item.ToString() == "RCRemote")
            {
                cm.PickedUpRCRemote(a, true);
            }
            else if (item.ToString() == "SpaceShip")
            {
                cm.PickedUpSpaceShip(a, true);
            }
        }
        if (interactor.transform.name == "Right Hand")
        {
            interactor.GetComponent<HandManager>().HideHand(false);
            if (item.ToString() == "Watergun")
            {
                cm.PickedUpWaterGun(a, false);
            }
            else if (item.ToString() == "RCRemote")
            {
                cm.PickedUpRCRemote(a, false);
            }
            else if (item.ToString() == "SpaceShip")
            {
                cm.PickedUpSpaceShip(a, false);
            }
        }
        base.OnSelectExit(interactor);
    }
}
