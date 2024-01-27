using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public GameObject bullet;
    public float bulletSpeed;
    public Rigidbody2D rb;
    public int maxHealth;
    private int health;
    private float interval;
    private float time;
    private int ammo;
    public int maxAmmo;

    

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        ammo = maxAmmo;
        calculateInterval();
    }

    // Update is called once per frame
    void Update()
    {
        

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        rb.velocity = new Vector2 (x, y)*speed;

        if (Input.GetKeyDown(KeyCode.Space) && ammo>0)
        {
            GameObject bulletTemp = Instantiate(bullet, transform.position, transform.rotation);
            Rigidbody2D rb = bulletTemp.GetComponent<Rigidbody2D>();
            Vector2 dir = new Vector3(0, 0) - transform.position;
            rb.AddForce(Vector2.down * bulletSpeed, ForceMode2D.Force);
            ammo--;
        }

        time += Time.deltaTime;

        if (time>interval)
        {
            if(!(ammo+1>maxAmmo))
            {
                ammo += 1;
            }
            time = 0;
        }



        
    }

    public void setHealth(int num)
    {
        health += num;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        calculateInterval();
    }

    public void calculateInterval()
    {
        interval = 5 - health / 20;
    }
}
