using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWarning : MonoBehaviour
{
    public GameObject guiElements;
    public float displayTime = 4f;

    private void Start()
    {
        guiElements.SetActive(false);
        Invoke("DisplayGUI",0.1f);
    }

    void DisplayGUI()
    {
        guiElements.SetActive(true);
        Invoke("HideGUI",displayTime);
    }

    void HideGUI()
    {
        guiElements.SetActive(false);
    }
}
