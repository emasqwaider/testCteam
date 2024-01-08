using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameInfo : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI namePlayer1;
    [SerializeField] TextMeshProUGUI namePlayer2;

    [SerializeField] TextMeshProUGUI timePlayer1;
    [SerializeField] TextMeshProUGUI timePlayer2;

    [SerializeField] TextMeshProUGUI sPlayer1;
    [SerializeField] TextMeshProUGUI sPlayer2;

    [SerializeField] TextMeshProUGUI winner;
    FileReadWriteDataSaver data;

    void Start()
    {
        data = GetComponent<FileReadWriteDataSaver>();
        data.Load();

        namePlayer1.text = data.player1.playerName;
        namePlayer2.text = data.player2.playerName;
        timePlayer1.text = data.player1.time.ToString(); 
        timePlayer2.text = data.player2.time.ToString();
        sPlayer1.text = data.player1.coins.ToString();
        sPlayer2.text = data.player2.coins.ToString();

        if (data.player1.time < data.player2.time)
        {
            //sPlayer1.text = "Winner";
            //sPlayer2.text = "Loser";
            winner.text = data.player1.playerName;
        }
        else if (data.player1.time > data.player2.time)
        {
            //sPlayer1.text = "Loser";
            //sPlayer2.text = "Winner";
            winner.text = data.player2.playerName;
        }
        else
        {
            //sPlayer1.text = "Tie";
            //sPlayer2.text = "Tie";
            winner.text = "Tie";
        }
    }

    void Update()
    {
    }
}
