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
    [SerializeField] bool isFinish;

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
            if (isFinish)
            {
                print("CROC");
                FindObjectOfType<MenuManager>().NextLevel();
            }

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
            if (transform.position != _babyIcon.transform.position)
                transform.position = Vector3.MoveTowards(transform.position, _babyIcon.transform.position, turnSpeed);
            else
                Destroy(gameObject);
        }
    }

    private void Update()
    {
        Movement();
    }
}