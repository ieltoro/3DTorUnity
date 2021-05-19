using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChange : MonoBehaviour
{

    public void ChangeGravity(bool a)
    {
        if(!a)
        {
            Physics.gravity = new Vector3(0, -5.81F, 0);
        }
        if(a)
            StartCoroutine(GravityNoneCD());

    }
    IEnumerator GravityNoneCD()
    {
        Physics.gravity = new Vector3(0, 0.3F, 0);
        yield return new WaitForSeconds(1f);
        Physics.gravity = new Vector3(0, -0.3f, 0);
        yield return new WaitForSeconds(1);
        Physics.gravity = new Vector3(0, 0, 0);
    }
}
