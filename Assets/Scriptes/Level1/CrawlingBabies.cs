using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrawlingBabies : MonoBehaviour
{
    public float horizontalSpeed;
    public bool isRight;
    public int health = 2;
    public float speed;
    private GameObject _player;
    public CapsuleCollider2D cd;
    public float turnSpeed;
    public bool hasCollided = true;

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
            transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, turnSpeed);
        }
    }

    private void Update()
    {
        Movement();
    }
}
