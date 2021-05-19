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

        if(a && tankOn)
            tankon.GetComponent<Rigidbody>().isKinematic = true;

        if (!a && tankOn)
            tankon.GetComponent<Rigidbody>().isKinematic = false;
        
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
        if(leftHand)
        {
            if (OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.LTouch))
            {
                if (tankOn)
                    DropTank();
            }
        }
        else
        {
            if (OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.RTouch))
            {
                if (tankOn)
                    DropTank();
            }
        }
        #endregion
    }
    public void ShootPaint()
    {
        if(tankOn)
        {
            part.Play();
        }
    }

    [Header("Color")]
    [SerializeField] ParticlesController pc;
    [SerializeField] BoxCollider colider;
    public Color paint;
    public Material mat;
    public bool tankOn;
    GameObject tankon;

    public void TankConnected(Color c, GameObject tank)
    {
        tankon = tank;
        paint = c;
        mat.color = paint;
        pc.paintColor = paint;
        tankOn = true;
    }

    public void DropTank()
    {
        print("DropHand");
        colider.enabled = false;
        tankon.transform.parent = null;
        tankon.GetComponent<Rigidbody>().isKinematic = false;
        tankOn = false;
        tankon = null;
        StartCoroutine(ActivateTank());
    }
    IEnumerator ActivateTank()
    {
        yield return new WaitForSeconds(0.3f);
        colider.enabled = true;
    }
}
