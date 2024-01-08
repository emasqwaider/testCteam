using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

   public  float startTime;
    private void OnEnable()
    {
        startTime = Time.time;
    }

    
    public float GetTime()
    {
        return Time.time - startTime;
    }
}
