using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner_Eren : MonoBehaviour
{
    enum sides
    {
         DOWN, LEFT, RIGHT
    }

    public GameObject enemy;
    public GameObject enemy2;
    sides side;
    private float Xpos;
    private float Ypos;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        side = sides.DOWN;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time > 5)
        {
            int random = Random.Range(1, 4);

            switch (random)
            {
                case 1:
                    side = sides.LEFT;
                    break;

                case 2:
                    side = sides.RIGHT;
                    break;

                case 3:
                    side = sides.DOWN;
                    break;
            }

            findPoint();
            throwEnemy();
            time = 0;
        }
        



    }
    public void findPoint()
    {
        if (side == sides.LEFT)
        {
            Xpos = -11; 
            Ypos = Random.Range(-5,3);
        }
        else if (side == sides.RIGHT)
        {
            Xpos = 11;
            Ypos = Random.Range(-5, 3);
        }
        
        else if (side == sides.DOWN)
        {
            Xpos = Random.Range(-9, 10);
            Ypos = -7;
        }
    }
    public void throwEnemy()
    {
        int num = Random.Range(0, 2);
        if (num == 0)
        {
            GameObject enemyTemp = Instantiate(enemy, new Vector3(Xpos, Ypos, 0), transform.rotation);
        }
        else
        {
            GameObject enemyTemp = Instantiate(enemy2, new Vector3(Xpos, Ypos, 0), transform.rotation);
        }
        
    }
}
