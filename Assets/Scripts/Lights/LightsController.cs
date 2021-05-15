using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsController : MonoBehaviour
{

    [SerializeField] Light[] lights;
    [SerializeField] Animator lightsAnim;

    public void PowerLights(bool a)
    {
        foreach(Light l in lights)
        {
            l.enabled = a;
        }
    }
    public void FadeLights(bool lightsOn)
    {
        lightsAnim.SetBool("Lights", lightsOn);
    }
}
