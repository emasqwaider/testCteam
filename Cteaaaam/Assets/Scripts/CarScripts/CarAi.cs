using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAi : MonoBehaviour
{
    [SerializeField] GameObject wayPointObject;
    [SerializeField] List<Transform> wayPoints = new List<Transform>();
    [SerializeField] int currentPoint;
    [SerializeField] float wayPointRange;

    [SerializeField] float engine = 200;
    [SerializeField] float steeringSpeed = 3f;

    [SerializeField] float targetAngle;
    CarController carMovement;

    private void Awake()
    {
        foreach (Transform t in wayPointObject.GetComponentInChildren<Transform>())
            wayPoints.Add(t);
    }

    private void Start()
    {
        currentPoint = 0;
        carMovement = GetComponent<CarController>();
    }

    private void Update()
    {

        if (Vector3.Distance(wayPoints[currentPoint].position, transform.position) < wayPointRange)
        {
            Debug.Log("currentPoint " + currentPoint);
            currentPoint++;
            if (currentPoint == wayPoints.Count) currentPoint = 0;
        }

        Vector3 targetDirection = wayPoints[currentPoint].position - transform.position;
         targetAngle = Vector3.SignedAngle(transform.forward, targetDirection, Vector3.up);

        

      carMovement.SetSteeringInput(targetAngle);

        if(targetAngle < -45 || targetAngle > 45)
        {
            carMovement.HandBrake();
        }else
        if(targetAngle < -150 || targetAngle > 150)
        {
            carMovement.Left();

        }else
        {
            carMovement.ApplyTraction();
        }


        carMovement.Forward();
        Debug.DrawRay(transform.position, wayPoints[currentPoint].position - transform.position, Color.red);
    }
}
