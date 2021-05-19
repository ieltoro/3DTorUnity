using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XROffsetGrab : XRGrabInteractable
{
    Vector3 initialAttachLocalPos;
    Quaternion initialAttachLocalRot;
    public enum Item { None, ColorTank}
    public Item item = Item.None;

    private void Start()
    {
        if(!attachTransform)
        {
            GameObject grab = new GameObject("Grab Pivot");
            grab.transform.SetParent(transform, false);
            attachTransform = grab.transform;
        }

        initialAttachLocalPos = attachTransform.localPosition;
        initialAttachLocalRot = attachTransform.localRotation;
    }

    protected override void OnSelectEnter(XRBaseInteractor interactor)
    {
        if(interactor.GetComponent<HandManager>() != null)
        {
            interactor.GetComponent<HandManager>().HideHand(true);
        }
        if (interactor is XRDirectInteractor)
        {
            attachTransform.position = interactor.transform.position;
            attachTransform.rotation = interactor.transform.rotation;
        }
        else
        {
            attachTransform.localPosition = initialAttachLocalPos;
            attachTransform.localRotation = initialAttachLocalRot;
        }
        if(item.ToString() == "ColorTank")
        {
            if (interactor.tag == "Hand")
            {
                gameObject.layer = 20;
                GetComponent<ColorTanks>().PickUpTank();
            }
        }
        base.OnSelectEnter(interactor);
    }
    protected override void OnSelectExit(XRBaseInteractor interactor)
    {
        base.OnSelectExit(interactor);
        if (item.ToString() == "ColorTank")
        {
            if (interactor.tag == "Hand")
            {
                GetComponent<ColorTanks>().DroppedFromHand();
                gameObject.layer = 18;
            }
        }
        if (interactor.GetComponent<HandManager>() != null)
        {
            interactor.GetComponent<HandManager>().HideHand(false);
        }
    }
}
