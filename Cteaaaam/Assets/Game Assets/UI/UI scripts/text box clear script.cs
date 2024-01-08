using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textboxclearscript : MonoBehaviour
{
    // Start is called before the first frame update
    public InputField input;    
    public void Start()
    {
        input.text = "";
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
