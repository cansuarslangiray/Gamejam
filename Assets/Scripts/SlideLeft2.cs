using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideLeft2 : MonoBehaviour {
		private Vector3 theTempVec;
    public Transform otherOrser;
    private float speed;

	void Start () {
        //Time.timeScale = 0f;
        speed = FindObjectOfType<GenerateLevel>().speed;
    }

    // Update is called once per frame
    void Update()
    {

        theTempVec = transform.position;

        if (theTempVec.y <= -21.6f)
        {
            theTempVec.y = otherOrser.position.y + 21.43f;
            transform.position = theTempVec;
        }
        else
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
    }
}
