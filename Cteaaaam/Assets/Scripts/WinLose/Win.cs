using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class Win : MonoBehaviour
{
    bool startCount;
    float time = 10;
    [SerializeField] TextMeshProUGUI timerText;
    //[SerializeField] float remainingTime;
    [SerializeField] SwitchScenes swithcScene;
    [SerializeField] GameObject particle;
    [SerializeField] int currentScene;

    private void Start()
    {
        swithcScene = FindAnyObjectByType<SwitchScenes>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            startCount = true;
            StartCoroutine(WaitAndSwitchLevel());
            Instantiate(particle, transform.position, transform.rotation);

            CarController carController = other.GetComponent<CarController>();
            if (carController != null)
            {
                if (carController.player1)
                {
                   float t = carController.GetComponent<Timer>().GetTime();
                   FileReadWriteDataSaver data =  FindAnyObjectByType<FileReadWriteDataSaver>();
                data.player1.time = t;
                if(data.player2.time == 0) 
                data.player2.time = t+10;

                    data.Save();  
                
                }
                else
                {
                    float t = carController.GetComponent<Timer>().GetTime();
                    FileReadWriteDataSaver data = FindAnyObjectByType<FileReadWriteDataSaver>();
                    data.player2.time = t;
                    if (data.player1.time == 0)
                        data.player1.time = t+10;

                    data.Save();
                }   
            }
        }
    }

    private void Update()
    {
        if(startCount)
        {
            Countdown();
        }

    }

    void Countdown()
    {
        if(time < 0.01f)
        {

        }
        else
        {
            time -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(time / 60);
            int seconds = Mathf.FloorToInt(time % 60);
            timerText.text = string.Format("{0:00}:{1:00}",minutes,seconds);
            Debug.Log("Test");
        }
        

        Debug.Log(time);
    }
    private IEnumerator WaitAndSwitchLevel()
    {

        yield return new WaitForSeconds(10f);

        if (currentScene == 1)
        {
            swithcScene.ActivateLevelTwo();
        }
        else if (currentScene == 2)
        {
            swithcScene.ActivateLevelThree();
        }else if(currentScene == 3)
        {
            swithcScene.ActivateRecordScene();
        }
    }
}
