using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerPointer : MonoBehaviour
{
    public bool pointing;
    [SerializeField] HandManager hm;

    public void VibrateController()
    {
        hm.VibrateController();
    }
}
