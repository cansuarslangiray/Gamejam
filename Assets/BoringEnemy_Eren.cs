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
    public LayerMask layerMask;
    public Animator animator;
    private bool haveBaby;
    public GameObject baby;
    public Transform babyPoint;

    private void Awake()
    {
        float rand = Random.Range(0f, 1f);

        if (rand<0.4)
        {
            haveBaby = true;
        }
        else
        {
            haveBaby = false;
        }


        if (haveBaby)
        {
            animator.SetTrigger("Steal");
        }
        
        y = Random.Range(-4,2);
        if (transform.position.x<0)
        {
            destination = new Vector3(9, y, 0)- transform.position;
        }
        else
        {
            destination =  new Vector3(-9, y, 0)- transform.position;
        }

        if (destination.x < 0)
        {
            transform.rotation = new Quaternion(0, 180, 0,0);
        }

        hit = Physics2D.Raycast(transform.position, destination,10,layerMask);
        
        Debug.DrawLine(transform.position, destination);
        if (hit)
        {
            
           GameObject unlemTemp = Instantiate(unlem,new Vector2(hit.point.x,hit.point.y) , transform.rotation);
            

        }
    }

    private void Update()
    {
        time += Time.deltaTime;

        if (time > 2)
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
            if (!haveBaby)
            {
                animator.SetTrigger("Steal");
            }
            Movement movement = collision.gameObject.GetComponent<Movement>();
            movement.setHealth(-1);
        }
        if (collision.gameObject.tag == "Bullet")
        {
            GameObject tempBaby = Instantiate(baby,babyPoint.position,babyPoint.rotation);
            Rigidbody2D rb = tempBaby.GetComponent<Rigidbody2D>();
            rb.gravityScale = 0.1f;
            rb.drag = 0;
            Destroy(collision.gameObject);
            Destroy(this.gameObject);

        }
    }
}
