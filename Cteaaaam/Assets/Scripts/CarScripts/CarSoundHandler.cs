using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSoundHandler : MonoBehaviour
{
    public AudioSource carEngineSound;
    public AudioSource tireScreechSound;
    float initialCarEngineSoundPitch;

    CarController Car;

    void Start()
    {
        Car = GetComponent<CarController>();

       
            initialCarEngineSoundPitch = carEngineSound.pitch;
       
    }

    void Update()
    {
        if (Car != null)
        {
            CarSound();
        }
        else
        {
            Debug.LogError("Car is null. Make sure the CarController component is present on the GameObject.");
        }
    }

    public void CarSound()
    {
        if (carEngineSound != null)
        {
            float engineSoundPitch = initialCarEngineSoundPitch + (Mathf.Abs(Car.carRigidbody.velocity.magnitude) / 25f);
            carEngineSound.pitch = engineSoundPitch;
        }

        if (tireScreechSound != null)
        {
            if (Car.isDrifting || (Car.isTractionLocked && Mathf.Abs(Car.carSpeed) > 12f))
            {
                if (!tireScreechSound.isPlaying)
                {
                    tireScreechSound.Play();
                }
            }
            else if (!Car.isDrifting && (!Car.isTractionLocked || Mathf.Abs(Car.carSpeed) < 12f))
            {
                tireScreechSound.Stop();
            }
        }
        else
        {
            Debug.LogError("tireScreechSound is null. Make sure it's assigned in the inspector.");
        }
    }
}
