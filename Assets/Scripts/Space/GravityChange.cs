using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChange : MonoBehaviour
{
    private void Start()
    {
        Physics.gravity = new Vector3(0, 0.0F, 0);
    }
    int i;
    //private void Update()
    //{
    //    if(Input.GetKeyDown(KeyCode.Space))
    //    {
    //        i++;
    //        if (i == 3)
    //            i = 0;
    //        print(i);
    //        if(i == 0)
    //            Physics.gravity = new Vector3(0, -5.81F, 0);
    //        if (i == 1)
    //            Physics.gravity = new Vector3(0, 0.3F, 0);
    //        if (i == 2)
    //            Physics.gravity = new Vector3(0, 0.0F, 0);
    //    }
    //}
}
