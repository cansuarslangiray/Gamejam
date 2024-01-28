using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrawlingBabies : MonoBehaviour
{
    public float horizontalSpeed;
    public bool isRight;
    public int health = 2;
    private float speed;
    private GameObject _babyIcon;
    private GameObject _babyIcon1;
    public CapsuleCollider2D cd;
    public float turnSpeed;
    public bool hasCollided = true;
    private GameObject babyBar;

    private void Start()
    {
        _babyIcon = GameObject.Find("BabyIcon");
        _babyIcon1 = GameObject.Find("BabyIcon1");
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
