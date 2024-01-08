using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreControl : MonoBehaviour
{
    FileReadWriteDataSaver data;
    [SerializeField] TextMeshProUGUI Score1;
    [SerializeField] TextMeshProUGUI Score2;

    void Start()
    {
        data = FindAnyObjectByType<FileReadWriteDataSaver>();
    }

    void Update()
    {

        Score1.text = data.player2.coins.ToString();
        Score2.text = data.player1.coins.ToString();
    }
    
}
