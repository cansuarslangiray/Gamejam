using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class EnemyBrain_Eren : MonoBehaviour
{
    private GameObject player;
    private Vector3 destination;
    public Rigidbody2D rb;
    public int Speed;
    public LayerMask layerMask;
    public RaycastHit2D hit;
    public GameObject unlem;
    public float time;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            destination = player.transform.position - transform.position;
        }

        hit = Physics2D.Raycast(transform.position, destination, 10, layerMask);

        if (hit)
        {
            GameObject unlemTemp = Instantiate(unlem, new Vector2(hit.point.x, hit.point.y), transform.rotation);
        }
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (time > 2)
        {
            destination = destination.normalized;
            rb.velocity = destination * Speed;
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Player") 
        {
            Debug.Log("Bebeði çaldým");
            Movement movement = collision.gameObject.GetComponent<Movement>();
            movement.setHealth(-1);
        }
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);

        }
    }


}
