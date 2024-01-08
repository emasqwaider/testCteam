using Mkey;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CarsActiveApi : MonoBehaviour
{
    [SerializeField] FileReadWriteDataSaver data;
    [SerializeField] GameObject allCars;
    [SerializeField] List<CarType> car = new List<CarType>();

    private void Start()
    {
        for(int i = 0; i < 100000; i++)
        {

        }
        for (int i = 0; i < allCars.transform.childCount; i++)
        {
            Debug.Log(i);
            CarType carType = allCars.transform.GetChild(i).GetComponent<CarType>();

            if (carType != null)
            {
                car.Add(carType);
            }
        }
    }

    private void Update()
    {
        TempTest();
    }
    void TempTest()
    {
        
        if(!data.player1.isAi)
        {
            foreach (CarType carType in car)
            {
                if (carType.CarNumber == data.player1.carType)
                {
                  //  carType.gameObject.GetComponent<CarAi>().enabled = false;
                    carType.gameObject.SetActive(true);
                    carType.gameObject.GetComponent<CarController>().player1 = true;
                    carType.gameObject.GetComponent<CarController>().player2 = false;

                    break;
                }
            }
        }else if(data.player1.isAi)
        {
            foreach (CarType carType in car)
            {
                if (carType.CarNumber == data.player1.carType)
                {
                    
                    data.player1.isAi = true;
                    carType.gameObject.SetActive(true);
                    carType.gameObject.GetComponent<CarController>().IsAi=true;
                    break;
                }
            }
        }

        if (!data.player2.isAi)
        {
            foreach (CarType carType in car)
            {
                if (carType.CarNumber == data.player2.carType)
                {
                    carType.gameObject.SetActive(true);
                  //  carType.gameObject.GetComponent<CarAi>().enabled = false;
                    carType.gameObject.GetComponent<CarController>().player1 = false;
                    carType.gameObject.GetComponent<CarController>().player2 = true;
                    break;
                }
            }
        }
        else if (data.player2.isAi)
        {
            foreach (CarType carType in car)
            {
                if (carType.CarNumber == data.player2.carType)
                {
                    data.player2.isAi = true;
                    carType.gameObject.SetActive(true);
                    carType.gameObject.GetComponent<CarController>().IsAi = true;
                    break;
                }
            }
        }
    }


}
