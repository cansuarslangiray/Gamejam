using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBabies : MonoBehaviour
{
    public int health = 1;
    public float speed;
    private GameObject _babyIcon;
    public CapsuleCollider2D cd;
    public float turnSpeed;
    public bool hasCollided = true;
    private GameObject babyBar;

    private void Start()
    {
        _babyIcon = GameObject.Find("BabyIcon");
        babyBar = GameObject.Find("GameManager");
        cd = GetComponent<CapsuleCollider2D>();
        speed = FindObjectOfType<GenerateLevel>().speed;
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.CompareTag("Player"))
        {
            col.transform.GetComponent<PlayerController>().IncreasingHealth(health);
            babyBar.transform.GetComponent<BabyBar>().IncreasingBabySlider(health);

            cd.enabled = false;
            hasCollided = false;
        }
    }

    void Movement()
    {

        if (hasCollided)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position,_babyIcon.transform.position, turnSpeed);
        }
    }

    private void Update()
    {
        Movement();
    }
}