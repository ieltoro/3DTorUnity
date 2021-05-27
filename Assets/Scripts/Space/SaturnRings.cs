using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaturnRings : MonoBehaviour
{
    ParticleSystem ps;
    public Vector3 rotationDirection;
    public float durationTime;
    private float smooth;
    void Start()
    {
        ps = FindObjectOfType<ParticleSystem>();
        ps.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        smooth = Time.deltaTime * durationTime;
        transform.Rotate(rotationDirection * smooth);
    }
}
