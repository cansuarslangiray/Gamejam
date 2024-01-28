using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseFallBabyCollide : MonoBehaviour
{
    private GameObject TempGameObject;
    public GameObject temp;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "FallBaby")
        {
            TempGameObject = GameObject.FindWithTag("GameManager");
            TempGameObject.GetComponent<FlappyBirdManager>().IncreaseHouseBabyDroped();
            Destroy(gameObject.transform.parent.gameObject);
            Destroy(collision.gameObject);
            Destroy(temp);

        }
    }
}
