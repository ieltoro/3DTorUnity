using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGunManager : MonoBehaviour
{
    [SerializeField] CharacterManager cm;

    [SerializeField] float shootCD;
    [SerializeField] ParticleSystem part;
    [SerializeField] GameObject bulletColorPrefab;
    [SerializeField] Transform outFrom;
    float canShoot = 0;
    bool leftHand;
    float triggerValue;

    public void ActivateGun(bool a, bool hand)
    {
        StopAllCoroutines();
        this.enabled = a;
        leftHand = hand;
    }

    private void Update()
    {
        #region Oculus Touch
        if (leftHand)
        {
            triggerValue = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.LTouch);
            if(triggerValue > 0.5f && Time.time >= canShoot)
            {
                canShoot = Time.time + 1 / shootCD;
                ShootPaint();
            }
        }
        else
        {
            triggerValue = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.RTouch);
            if (triggerValue > 0.5f && Time.time >= canShoot)
            {
                {
                    canShoot = Time.time + 1 / shootCD;
                    ShootPaint();
                }
            }
        }
        #endregion
    }
    public void ShootPaint()
    {
        print("Shoot");
        Instantiate(bulletColorPrefab, outFrom.position, outFrom.rotation);
    }

}
