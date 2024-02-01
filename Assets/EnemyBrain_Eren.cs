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
    public Animator animator;
    public AudioSource storkSound;
    public AudioSource deadSound;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            destination = player.transform.position - transform.position;
        }

        if (destination.x < 0)
        {
            transform.rotation = new Quaternion(0, 180, 0, 0);
        }

        hit = Physics2D.Raycast(transform.position, destination, 10, layerMask);

        if (hit)
        {
            GameObject unlemTemp = Instantiate(unlem, new Vector2(hit.point.x, hit.point.y), transform.rotation);
        }

        storkSound.Play();
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
            Debug.Log("Bebeggi ccaldiim");
            animator.SetTrigger("Steal");
            Movement movement = collision.gameObject.GetComponent<Movement>();
            movement.setHealth(-1);
        }
        if (collision.gameObject.tag == "Bullet")
        {
            //Bullet gelince bebeðin pivot noktasýndan bebek instanciate etmeliyiz 
            deadSound.Play();
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }


}
