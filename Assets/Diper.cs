using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Diper : MonoBehaviour
{
    public int diaperNum;
    public int maxDiaperNum;
    public Image[] diapers;
    public Movement movement;

    private void Update()
    {
        diaperNum = movement.getAmmo();
        for (int i = 0; i < diapers.Length; i++)
        {
            if (i <= diaperNum)
            {
                diapers[i].enabled=true;
            }
            else if(i>diaperNum) 
            {

                diapers[i].enabled=false;
            }
        }
    }
}
