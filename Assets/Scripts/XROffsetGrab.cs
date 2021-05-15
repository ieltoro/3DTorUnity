using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XROffsetGrab : XRGrabInteractable
{
    Vector3 initialAttachLocalPos;
    Quaternion initialAttachLocalRot;
    [SerializeField] bool rcRemote;
    [SerializeField] 
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
        if(rcRemote)
        {
            interactor.GetComponent<HandManager>().DisplayRemoteController(true);
        }

        interactor.GetComponent<HandManager>().HideHand(true);
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
        base.OnSelectEnter(interactor);
    }
    protected override void OnSelectExit(XRBaseInteractor interactor)
    {
        if (rcRemote)
        {
            interactor.GetComponent<HandManager>().DisplayRemoteController(false);
        }
        interactor.GetComponent<HandManager>().HideHand(false);
        base.OnSelectExit(interactor);
    }
}
