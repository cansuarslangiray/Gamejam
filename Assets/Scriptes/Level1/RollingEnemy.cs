using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingEnemy : MonoBehaviour
{
    public int damage = 2;
    public float speed;
    private GameObject _player;
    public float horizontalSpeed;
    public bool isRight;

    private void Start()
    {
        _player = GameObject.Find("Player");
        
    }

  
  
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.CompareTag("Player"))
        {
            col.transform.GetComponent<PlayerController>().TakeDamage(damage);
        }
    }

    void Movement()
    {
        transform.Translate(Vector3.down*speed*Time.deltaTime);
        if (isRight)
        {
            transform.Translate(Vector3.right*horizontalSpeed*Time.deltaTime);
        }
        else
        {
            transform.Translate(-Vector3.right*horizontalSpeed*Time.deltaTime);
        }
    }

    void DestoyEnemy()
    {
        if (transform.position.y < _player.transform.position.y - 10)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        Movement();
        DestoyEnemy();
    }
}