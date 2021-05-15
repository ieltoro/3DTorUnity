using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeChangePlayer : MonoBehaviour
{
    bool active;
    float targetSize, currentSize = 1, startSize, time, speed;
    [SerializeField] float sizeSpeed;
    [SerializeField] GameObject player;


    public void ChangeSize(int Direction)
    {
        print("SizeChange");
        if(Direction == -1) // Smal
        {
            startSize = currentSize;
            speed = sizeSpeed;
            targetSize = 0.1f;
            time = 0;
            active = true;
        }
        if(Direction == 0) // Normal
        {
            speed = sizeSpeed;
            startSize = currentSize;
            targetSize = 1;
            time = 0;
            active = true;
        }
        if(Direction == 1) // Big
        {
            startSize = currentSize;
            speed = sizeSpeed;
            targetSize = 3;
            time = 0;
            active = true;
        }
    }

    void Update()
    {
        if (active)
        {
            time += Time.deltaTime * speed;
            currentSize = Mathf.Lerp(startSize, targetSize, time);
            player.transform.localScale = new Vector3(currentSize, currentSize, currentSize);
        }
    }
}
