using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
public class CarParticalsSystem : MonoBehaviour
{
    // The following particle systems are used as tire smoke when the car drifts.
    public ParticleSystem RLWParticleSystem;
    public ParticleSystem RRWParticleSystem;

    // The following trail renderers are used as tire skids when the car loses traction. 
    public TrailRenderer RLWTireSkid;
    public TrailRenderer RRWTireSkid;

    private CarController CarController;
    void Start()
    {
        CarController =GetComponent<CarController>();
    }

    void Update()
    {
        
    }

    public void ApplyParticals(bool b = false)
    {
        if(CarController.isDrifting || b)
        {
            RLWParticleSystem.Play();
            RRWParticleSystem.Play();
        }else
       
            if(!CarController.isDrifting)
        {
            RLWParticleSystem.Stop();
            RRWParticleSystem.Stop();
        }

        if ((CarController.isTractionLocked || Mathf.Abs(CarController.XVelocity) > 4) && Mathf.Abs(CarController.carSpeed) > 10)
        {
            RLWTireSkid.emitting = true;
            RRWTireSkid.emitting = true;
        }
        else
        {
            RLWTireSkid.emitting = false;
            RRWTireSkid.emitting = false;
        }

        
    }
}
