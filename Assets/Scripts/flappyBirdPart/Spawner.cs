using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawnRate = 1f;
    public float minHeight = -1f;
    public float maxHeight = 1f;
    public float babyChance;
    public float houseChance;
    public Sprite[] sprites;


    public void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }
    public void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    public void Spawn()
    {
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);

        //baby enable chance
        int tempRandom = Random.RandomRange(0, 100);
        if( tempRandom < babyChance)
        {
            pipes.transform.GetChild(0).gameObject.SetActive(true);
        }

        //house enable chance
        int tempRandom2 = Random.RandomRange(0, 100);
        int tempRandom3 = Random.RandomRange(0, sprites.Length);

        if (tempRandom2 < houseChance)
        {
            pipes.transform.GetChild(4).gameObject.SetActive(true);
            pipes.transform.GetChild(4).gameObject.GetComponent<SpriteRenderer>().sprite = sprites[tempRandom3];
        }
        
    }
}
