using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSaveBase : MonoBehaviour
{

    void Start()
    {
        Load();
    }

    public virtual void Save() { }
    public virtual void Load() { }

    void OnGUI()
    {
        if (GUILayout.Button("Save"))
            Save();

        if (GUILayout.Button("Load"))
            Load();
    }
}