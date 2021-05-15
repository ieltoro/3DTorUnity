using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxManager : MonoBehaviour
{
    [SerializeField] Material[] skies;
    public void ChangeSkybox(int nr)
    {
        RenderSettings.skybox = skies[nr];
    }
}
