using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float turnSpeed;
    private float targertPos = 0;
    public int health = 1;
    public int currentScene = 1;
    public GameObject deadUi;
    private bool _canMove;


    void PlayerMovement()
    {
        if (transform.position.x == targertPos)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (transform.position.x > -4)
                {
                    targertPos -= 4;
                    transform.DORotate(new Vector3(0, 0, 45), 0.3f).OnComplete(() =>
                    {
                        transform.DORotate(new Vector3(0, 0, 0), 0.3f);
                    });
                }
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                if (transform.position.x < 4)
                {
                    _canMove = true;
                    targertPos += 4;
                    transform.DORotate(new Vector3(0, 0, -45), 0.3f).OnComplete(() =>
                    {
                        transform.DORotate(new Vector3(0, 0, 0), 0.3f);
                    });
                }
            }
        }


        transform.position = Vector3.MoveTowards(transform.position,
            new Vector3(targertPos, transform.position.y, 0), turnSpeed);
    }

    private void Update()
    {
        PlayerMovement();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            PauseGame();
            deadUi.SetActive(true);
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0;
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void ReloadScene()
    {
        deadUi.SetActive(false);
        ResumeGame();
        SceneManager.LoadScene(currentScene);
    }

    public void IncreasingHealth(int healthPoint)
    {
        health += healthPoint;
    }
}