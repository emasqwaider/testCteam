using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carmodels : MonoBehaviour
{
    public int index;
    public GameObject[] car__ = new GameObject[4];

    // Start is called before the first frame update
    void Start()
    {
       index = PlayerPrefs.GetInt("selectdcar", 0);
       foreach(GameObject car in car__)
        {
            car.SetActive(false);
        }
        car__[index].SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeCarRightclick()
    {
        car__[index].SetActive(false);index++;
        if(index == car__.Length)
        {
            index = 0;
        }
        car__[index].SetActive(true);

        PlayerPrefs.SetInt("selectdcar", index);
    }

    public void changeCarLeftclick()
    {
        car__[index].SetActive(false); index--;
        if (index == -1)
        {
            index = car__.Length - 1;
        }
        car__[index].SetActive(true);

        PlayerPrefs.SetInt("selectdcar", index);
    }
}
