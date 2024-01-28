using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
  public GameObject GameObject;
  public GameObject GameObject1;

  public void Active()
  {
    GameObject.SetActive(true);
    GameObject1.SetActive(true);
  }
}
