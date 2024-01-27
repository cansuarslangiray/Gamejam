using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoringEnemy_Eren : MonoBehaviour
{
    RaycastHit2D hit;
    private Vector3 destination;
    public Rigidbody2D rb;
    public int Speed;
    public float y;
    public GameObject unlem;
    private float time;

    private void Awake()
    {
        y = Random.Range(-4,2);
        if (transform.position.x<0)
        {
            destination = new Vector3(9, y, 0)- transform.position;
        }
        else
        {
            destination =  new Vector3(-9, y, 0)- transform.position;
        }

        Debug.Log(destination);

        hit = Physics2D.Raycast(transform.position, destination,10);
        Debug.DrawLine(transform.position, destination);
        if (hit)
        {
            Debug.Log(hit.point);
            if (hit.point.x == -9)
            {
                GameObject unlemTemp = Instantiate(unlem,new Vector2(hit.point.x+0.5f,hit.point.y) , transform.rotation);
            }
            else if(hit.point.x == 9)
            {
                GameObject unlemTemp = Instantiate(unlem, new Vector2(hit.point.x - 0.5f, hit.point.y), transform.rotation);
            }
            else if (hit.point.y == 5)
            {
                GameObject unlemTemp = Instantiate(unlem, new Vector2(hit.point.x, hit.point.y-0.5f), transform.rotation);
            }
            else if (hit.point.x == 9)
            {
                GameObject unlemTemp = Instantiate(unlem, new Vector2(hit.point.x, hit.point.y + 0.5f), transform.rotation);
            }

        }
    }

    private void Update()
    {
        time += Time.deltaTime;

        if (time > 3)
        {
            destination = destination.normalized;
            rb.velocity = destination * Speed;
            Debug.DrawLine(transform.position,new Vector2(transform.position.x+rb.velocity.x, transform.position.y + rb.velocity.y),Color.red);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
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
