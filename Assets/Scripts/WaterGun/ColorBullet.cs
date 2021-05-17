using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBullet : MonoBehaviour
{
    [SerializeField] GameObject collisionPrefab;
    [SerializeField] Rigidbody rb;
    Vector3 force;
    void Start()
    {
        force = new Vector3(15, 0, 0);
        rb.AddRelativeForce(force, ForceMode.Impulse);
        //rb.AddForce(force, ForceMode.Impulse);
        Destroy(gameObject, 4);
    }
    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.right, contact.normal);
        Vector3 pos = contact.point;
        Instantiate(collisionPrefab, pos, rot);
        Destroy(gameObject);
    }
}
