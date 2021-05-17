using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGunManager : MonoBehaviour
{
    [SerializeField] CharacterManager cm;
    [SerializeField] float triggerValue, gripValue, shootCD;
    bool canShoot;
    bool leftHand;

    public void ActivateGun(bool a, bool hand)
    {
        this.enabled = a;
        leftHand = hand;
        canShoot = a;

        print("Water gun is enabled? " + a + ": And using left hand? " + hand);
        if (a)
        {

        }
        else
        {

        }
    }

    private void Update()
    {
        #region Oculus Touch
        if (leftHand)
        {
            triggerValue = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.LTouch);
            if(triggerValue > 0.5f)
            {
                if(canShoot)
                    ShootPaint();
            }
        }
        else
        {
            triggerValue = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.RTouch);
            if (triggerValue > 0.5f)
            {
                if (canShoot)
                    ShootPaint();
            }
        }
        #endregion
    }
    public void ShootPaint()
    {
        canShoot = false;
        StartCoroutine(ShootWait());
    }
    IEnumerator ShootWait()
    {
        yield return new WaitForSeconds(shootCD);
        canShoot = true;
    }
}
