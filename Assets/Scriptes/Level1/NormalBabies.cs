using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBabies : MonoBehaviour
{
    public int health = 1;
    public float speed;
    private GameObject _player;
    public CapsuleCollider2D cd;
    public float turnSpeed;
    public bool hasCollided = true;
    public float babyDistance = 0.1f;

    private void Start()
    {
        _player = GameObject.Find("Player");
        cd = GetComponent<CapsuleCollider2D>();
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.CompareTag("Player"))
        {
            _player.GetComponent<PlayerController>().currentBaby++;
            col.transform.GetComponent<PlayerController>().IncreasingHealth(health);
            cd.enabled = false;
            hasCollided = false;
        }
    }

    void Movement()
    {
      /*  var distance =0f;
        for (int i =0;i< _player.GetComponent<PlayerController>().currentBaby;i++)
        {
            distance += babyDistance;
        }*/

        var pos = _player.transform.position.y - babyDistance;
        if (hasCollided)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position,_player.transform.position, turnSpeed);
        }
    }

    private void Update()
    {
        Movement();
    }
}