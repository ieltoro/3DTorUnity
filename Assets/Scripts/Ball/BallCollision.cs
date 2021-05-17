using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    public GameObject instantiateObj;
    public bool active;
    private void OnCollisionEnter(Collision collision)
    {
        if(active)
        {
            ContactPoint contact = collision.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;
            Instantiate(instantiateObj, pos, rot);
            Destroy(gameObject);
        }
    }
}
