using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrawlingBabies : MonoBehaviour
{
    public float horizontalSpeed;
    public bool isRight;
    public int health = 2;
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
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _babyIcon.transform.position, turnSpeed);
        }
    }

    private void Update()
    {
        Movement();
    }
}
