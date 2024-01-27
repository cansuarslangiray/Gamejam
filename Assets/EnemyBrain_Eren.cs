using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBrain_Eren : MonoBehaviour
{
    private GameObject player;
    private Vector3 destination;
    public Rigidbody2D rb;
    public int Speed;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            destination = player.transform.position - transform.position;
        }
    }

    private void Update()
    {

        destination = destination.normalized;
        rb.velocity = destination * Speed;


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Player") 
        {
            Debug.Log("Bebeði çaldým");
        }
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);

        }
    }


}
