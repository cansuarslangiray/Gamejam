using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabySpawner : MonoBehaviour
{
    public float timeInterval;
    public float time;

    [SerializeField]
    private float max;
    [SerializeField]
    private float min;
    public GameObject baby;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > timeInterval)
        {
            GameObject tempBaby = Instantiate(baby,new Vector3(Random.Range(min,max),6,0), transform.rotation);
            time = 0;
        }
    }
}
