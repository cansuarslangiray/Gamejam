using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycastCheck : MonoBehaviour
{
    private RaycastHit2D hit;
    public GameObject tempHouse;

    public void Awake()
    {
        hit = Physics2D.Raycast(transform.position, new Vector2(0,-1), 10f);

        if (hit)
        {
            tempHouse.transform.position = hit.point;
            Debug.DrawLine(transform.position,hit.point);
        }
    }

    public void Update()
    {
       
        Debug.DrawLine(transform.position,hit.point);
    }
}
