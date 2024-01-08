using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Lives : MonoBehaviour
{
    public int maxLives = 3;
    private int currentLivesP1 = 3;
    private int currentLivesP2 = 3;
    public int collsionCounterP1 = 0;
    public int collsionCounterP2 = 0;

    [SerializeField] TextMeshProUGUI livesTextP1; 
    [SerializeField] TextMeshProUGUI livesTextP2;

    void Start()
    {
        //currentLivesP1 = maxLives;
        //currentLivesP2 = maxLives;
        UpdateLivesUI();
    }

    void UpdateLivesUI()
    {
        if (livesTextP1 != null)
        {
            livesTextP1.text = "Lives: " + currentLivesP1;
        }
        if (livesTextP2 != null)
        {
            livesTextP2.text = "Lives: " + currentLivesP2;
        }
    }

    void LoseLifeP1()
    {
        collsionCounterP1++;
        currentLivesP1--;

        if (currentLivesP1 <= 0)
        {
            livesTextP1.text = "Lives: " + 0 ;
            Debug.Log("Game Over Player 1");
        }
        else
        {
            UpdateLivesUI();
        }
    }
    void LoseLifeP2()
    {
        collsionCounterP2++;
        currentLivesP2--;

        if (currentLivesP2 <= 0)
        {
            livesTextP2.text = "Lives: " + 0;
            Debug.Log("Game Over Player 2");
        }
        else
        {
            UpdateLivesUI();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        CarController carController = collision.gameObject.GetComponent<CarController>();
        if (carController != null)
            if (carController.player1)
            {
                if (collsionCounterP1 <= 0)
                    LoseLifeP1();
            }
            else
            {
                if (collsionCounterP2 <= 0)
                    LoseLifeP2();
            }
    }
}
