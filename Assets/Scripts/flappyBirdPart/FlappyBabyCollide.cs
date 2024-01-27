using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyBabyCollide : MonoBehaviour
{
    private GameObject TempGameObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            TempGameObject = GameObject.FindWithTag("GameManager");
            TempGameObject.GetComponent<FlappyBirdManager>().IncreaseScore();
            Destroy(this.gameObject);
        }
    }
}
