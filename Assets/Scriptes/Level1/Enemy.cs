using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage = 1;
    public float speed;
    private GameObject _player;

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
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    void DestoyEnemy()
    {
        if (transform.position.y < _player.transform.position.y - 15)
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
