using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotator : MonoBehaviour
{
    public int rotationspeed = 25;
    void Update()
    {
        transform.Rotate(0, rotationspeed * Time.deltaTime, 0);
    }
}
