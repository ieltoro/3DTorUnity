using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSphare : MonoBehaviour
{

    [SerializeField] AudioSource audioS;
    MeshRenderer meshR;
    [SerializeField] float dispAmount;


    void Start()
    {
        meshR = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        audioS.Play();
        meshR.material.SetFloat("_Scale", dispAmount);
        meshR.material.SetColor("_Color", Color.blue);
        meshR.material.SetColor("_FresnelColor", Color.red *1f);
    }
    private void OnTriggerExit(Collider other)
    {
        audioS.Stop();
        meshR.material.SetFloat("_Scale", 0);
        meshR.material.SetColor("_Color", Color.white);
        meshR.material.SetColor("_FresnelColor", Color.white * 0f);
    }
}
