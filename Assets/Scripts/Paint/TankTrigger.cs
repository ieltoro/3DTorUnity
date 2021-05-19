using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankTrigger : MonoBehaviour
{
    public WaterGunManager wgm;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ColorTank")
        {
            other.GetComponent<ColorTanks>().Connected(gameObject);
            wgm.TankConnected(other.GetComponent<ColorTanks>().color, other.gameObject);
        }
    }
}
