using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
    public Transform crossHair;
    public TextMeshProUGUI tempText;

    

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        ammo = maxAmmo;
        tempText.text = maxAmmo.ToString();
        calculateInterval();
    }

    // Update is called once per frame
    void Update()
    {
        

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        rb.velocity = new Vector2 (x, y)*speed;

        /*var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f;

        var halfPos = transform.position+(mouseWorldPos- transform.position)/2;
        crossHair.position = halfPos;*/

        if (Input.GetKeyDown(KeyCode.Space) && ammo>0)
        {
            GameObject bulletTemp = Instantiate(bullet, transform.position, new Quaternion(0,0,-90,0));
            Rigidbody2D rb = bulletTemp.GetComponent<Rigidbody2D>();
            //Vector2 dir = new Vector2(0,-1) - transform.position;
            rb.AddForce(new Vector2(0,-1) * bulletSpeed, ForceMode2D.Force);
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
        tempText.text = health.ToString();
        calculateInterval();
    }

    public int getAmmo()
    {
        return ammo;
    }

    public int getHealth()
    {
        return health;
    }

    public void calculateInterval()
    {
        interval = 5 - health / 20;
    }
}
