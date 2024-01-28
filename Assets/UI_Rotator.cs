using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Rotator : MonoBehaviour
{
    [SerializeField]
    private RectTransform parent;
    public GameObject babyHead;
    public Movement movement;
    private GameObject[] heads;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateHeads() 
    {
        foreach (var head in heads)
        {
            Destroy(head.gameObject);
        }
        int babyNum = movement.getHealth();
        float degree = 2*Mathf.PI / babyNum;
        float angle = 0;

        
        heads = new GameObject[babyNum];
        

        for (int i = 0; i < babyNum; i++)
        {
            GameObject go = Instantiate(babyHead,transform.position,new Quaternion(0,0,degree*i,0));
            go.transform.parent=this.transform;
            heads[i] = go;
        }
    }
}
