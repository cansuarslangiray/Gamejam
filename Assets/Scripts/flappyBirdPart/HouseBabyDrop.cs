using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseBabyDrop : MonoBehaviour
{
    private GameObject TempGameObject;
    public GameObject Baby;
    private GameObject InstBaby;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            TempGameObject = GameObject.FindWithTag("GameManager");
            TempGameObject.GetComponent<GameManager>().DecreaseScore();
            InstBaby = Instantiate(Baby, GameObject.FindWithTag("Player").transform.position, Quaternion.identity);
            Rigidbody2D rb = InstBaby.GetComponent<Rigidbody2D>();
            rb.AddForce(Vector2.down,ForceMode2D.Impulse);
            
        }
    }


}
