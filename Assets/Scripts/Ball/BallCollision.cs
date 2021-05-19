using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    public GameObject instantiateObj;
    bool active;
    public void SetActive()
    {
        active = true;
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (active)
    //    {
    //        ContactPoint contact = collision.contacts[0];
    //        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
    //        Vector3 pos = contact.point;
    //        Instantiate(instantiateObj, pos, rot);
    //        Destroy(gameObject);
    //    }
    //}
}
