using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_Eren : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Baby" || collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
        }
    }
}
