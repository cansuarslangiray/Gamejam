using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exclamation : MonoBehaviour
{
    private float time = 0; 

    
    void Update()
    {
        time += Time.deltaTime;

        if (time > 2)
        {
            Destroy(this.gameObject);
        }
    }
}
