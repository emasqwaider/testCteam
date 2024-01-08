using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CarLightHandler : MonoBehaviour
{
    [SerializeField] Light frontLight1;
    [SerializeField] Light frontlight2;
    [SerializeField] Light backlight1;
    [SerializeField] Light backlight2;

    int counter = 0;
    void Start()
    {
        
    }

    void Update()
    {
      if(Input.GetKeyDown(KeyCode.L))
        {
            if(counter == 0)
            {
                StartFrontLight();
            }else if (counter == 1)
            {
                MidFrontLight();
            }else if (counter == 2)
            {
                HighFrontLight();
            }else if(counter == 3)
            {
                StopFrontLight();
            }
            counter ++;
            if(counter > 3)
            {
                counter = 0;
            }


        }
    }

    public void StartHandBrakeLight()
    {
        backlight1.intensity = 0.5f;
        backlight2.intensity = 0.5f;
    }
    public void StopHandBrakeLight()
    {
        backlight1.intensity = 0;
        backlight2.intensity = 0;
    }

    public void StartFrontLight()
    {
        frontLight1.intensity = 5;
        frontlight2.intensity = 5;
    }

    public void StopFrontLight()
    {
        frontLight1.intensity = 0;
        frontlight2.intensity = 0;
    }
    public void MidFrontLight()
    {
        frontLight1.intensity = 10;
        frontlight2.intensity = 10;
    }

    public void HighFrontLight()
    {
        frontLight1.intensity = 20;
        frontlight2.intensity = 20;
    }



}
