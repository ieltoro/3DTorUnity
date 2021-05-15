using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBounds : MonoBehaviour
{
    public GameObject insideObj;
    private void OnTriggerEnter(Collider other)
    {
        insideObj.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        insideObj.SetActive(false);
    }
}
