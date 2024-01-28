
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
    public int healthPoint;


    void PlayerMovement()
    {
        if (transform.position.x == targertPos)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (transform.position.x > -4)
                {
                    targertPos -= 4;
                    transform.DORotate(new Vector3(0, 0, 25), 0.18f).OnComplete(() =>
                    {
                        transform.DORotate(new Vector3(0, 0, 0), 0.18f);
                    });
                }
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                if (transform.position.x < 4)
                {
                    _canMove = true;
                    targertPos += 4;
                    transform.DORotate(new Vector3(0, 0, -25), 0.18f).OnComplete(() =>
                    {
                        transform.DORotate(new Vector3(0, 0, 0), 0.18f);
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
        else
        {
            if (transform.position.x == 0)
            {
                int i = Random.Range(0, 2);
                i--;
                targertPos += 4 * i;
                transform.DORotate(new Vector3(0, 0, -25 * i), 0.18f).OnComplete(() =>
                {
                    transform.DORotate(new Vector3(0, 0, 0), 0.18f);
                });
                return;
            }

            if (transform.position.x > -4)
            {
                targertPos -= 4;
                transform.DORotate(new Vector3(0, 0, 25), 0.18f).OnComplete(() =>
                {
                    transform.DORotate(new Vector3(0, 0, 0), 0.18f);
                });
            }

            if (transform.position.x < 4)
            {
                _canMove = true;
                targertPos += 4;
                transform.DORotate(new Vector3(0, 0, -25), 0.18f).OnComplete(() =>
                {
                    transform.DORotate(new Vector3(0, 0, 0), 0.18f);
                });
            }
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0;
    }

 
  
    void ResumeGame ()
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

