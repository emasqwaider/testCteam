using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        FileReadWriteDataSaver data = FindAnyObjectByType<FileReadWriteDataSaver>();

        if (data != null)
        {
            data.Load();

            CarController carController = collision.gameObject.GetComponent<CarController>();

                if (carController != null) 
                if (carController.player1)
                {
                    data.player1.coins += 1;
                }
                else
                {
                    data.player2.coins += 1;
                }
           

            data.Save();
            Destroy(gameObject);
        }
       
    }


}
