using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBabies : MonoBehaviour
{public int health = 1;
    public float speed;
    private GameObject _player;

    private void Start()
    {
        _player = GameObject.Find("Player");
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Player"))
        {
            col.transform.GetComponent<PlayerController>().IncreasingHealth(health);
            
        }
    }

    void Movement()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
    

    
}
