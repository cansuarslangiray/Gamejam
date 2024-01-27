using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Eren : MonoBehaviour
{
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Destroyer")
        {
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);

        }
    }
}
