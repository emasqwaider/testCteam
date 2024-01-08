using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    bool isPlayer1;
    void Start()
    {
        isPlayer1 = GetComponentInParent<CarController>().player1;
        if(isPlayer1)
        {
            Camera camera = GetComponent<Camera>();
            Rect viewPort = new Rect(0.5f, 0, 1, 1);
            camera.rect = viewPort;
        }else
        {
            Camera camera = GetComponent<Camera>();
            Rect viewPort = new Rect(-0.5f, 0, 1, 1);
            camera.rect = viewPort;
        }

    }

    
}
