using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector3 direction;
    public float gravity = -9.8f;
    public float strength = 5f;
    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;
    public GameObject gamemanager;
    public AudioSource flapSound;


    public void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        gamemanager = GameObject.FindWithTag("GameManager");
    }

    public void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }



    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)|| Input.GetMouseButtonDown(0))
        {
            direction = Vector3.up * strength;
            flapSound.Play();
        }

        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                direction = Vector3.up * strength;
            }
        }

        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;

        Debug.Log("Number of house baby droped");
        if (gamemanager.GetComponent<FlappyBirdManager>().getHouseBabyDropped()>=20)
        {
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            Debug.Log("Should go next scene");
            print("ALLIGATOR");
            FindObjectOfType<MenuManager>().NextLevel();
        }
    }

    public void AnimateSprite()
    {
        spriteIndex++;

        if(spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }

        spriteRenderer.sprite = sprites[spriteIndex];
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            FindObjectOfType<FlappyBirdManager>().GameOver();
        }

        else if(collision.gameObject.tag == "Scoring")
        {
            FindObjectOfType<FlappyBirdManager>().IncreaseScore();
        }
    }
}
