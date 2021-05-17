using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGunManager : MonoBehaviour
{
    [SerializeField] CharacterManager cm;

    [SerializeField] float shootCD;
    [SerializeField] ParticleSystem part;
    bool canShoot;
    bool leftHand;
    float triggerValue;

    public void ActivateGun(bool a, bool hand)
    {
        StopAllCoroutines();
        this.enabled = a;
        leftHand = hand;
        canShoot = a;
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
                {
                    canShoot = false;
                    ShootPaint();
                }
            }
        }
        else
        {
            triggerValue = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.RTouch);
            if (triggerValue > 0.5f)
            {
                if (canShoot)
                {
                    canShoot = false;
                    ShootPaint();
                }
            }
        }
        #endregion
    }
    public void ShootPaint()
    {
        print("Shoot");
        part.Play();
        StartCoroutine(ShootWait());
    }
    IEnumerator ShootWait()
    {
        yield return new WaitForSeconds(shootCD);
        canShoot = true;
    }
}
