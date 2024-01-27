using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public GameObject bullet;
    public float bulletSpeed;
    public Rigidbody2D rb;

    //public GameObject[] crosshairs;

    // Start is called before the first frame update
    void Start()
    {
        /*for (int i = 0; i < crosshairs.Length; i++)
        {
            GameObject s = Instantiate(crosshairs[i]);
            crosshairs[i] = s;
        }*/

    }

    // Update is called once per frame
    void Update()
    {
        

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        rb.velocity = new Vector2 (x, y)*speed;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bulletTemp = Instantiate(bullet, transform.position, transform.rotation);
            Rigidbody2D rb = bulletTemp.GetComponent<Rigidbody2D>();
            Vector2 dir = new Vector3(0, 0) - transform.position;
            rb.AddForce(Vector2.down * bulletSpeed, ForceMode2D.Force);
        }



        /*for (int i = 0; i < crosshairs.Length; i++)
        {
            crosshairs[i].transform.position = transform.position + (transform.position / -5)*i;
        }*/
    }
}
