using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltTracking : MonoBehaviour
{
    [SerializeField] Transform head; 


    void Update()
    {
        float y = head.position.y /2;
        transform.position = new Vector3(head.position.x, y, head.position.z);
        transform.rotation = new Quaternion(0, head.rotation.y, 0, 1);
    }
}
