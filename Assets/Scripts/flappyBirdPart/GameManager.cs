using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    private int score=0;
    public Text scoreText;
<<<<<<< Updated upstream
    public GameObject playButton;
    public GameObject gameOver;
    public Player player;
=======

    public GameObject playButton;
    public GameObject gameOver;

    public Player player;
    public GameObject playerG_ObjectVersion;
    public int babycount;
    public GameObject tempPlayerTailBaby;
    public GameObject[] tailBabyArray;
    public Vector2 tempPlace;

    private int houseBabyDroped;
    public Text houseBabyDropedText; 

    //snake video
        //private List<Transform> _segments;
        //public Transform segmentPrefab;
    //snake video
        /*public void Start()
        {
            _segments = new List<Transform>();
            _segments.Add(playerG_ObjectVersion.transform);
        }*/
>>>>>>> Stashed changes

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
<<<<<<< Updated upstream
=======
    public void DecreaseScore()
    {
        score--;
        scoreText.text = score.ToString();
    }

    public void IncreaseHouseBabyDroped()
    {
        houseBabyDroped++;
        houseBabyDropedText.text = houseBabyDroped.ToString();
        
    }

>>>>>>> Stashed changes

    public void GameOver()
    {
        Debug.Log("Game Over");
        gameOver.SetActive(true);
        playButton.SetActive(true);
        Pause();
    }

    public void Awake()
    {
        Application.targetFrameRate = 60;
        Pause();
<<<<<<< Updated upstream
=======


        /*tailBabyArray = new GameObject[babycount];
        InstanciatePlayerTailBaby();*/
>>>>>>> Stashed changes
    }

    public void Play()
    {
<<<<<<< Updated upstream
        score = 0;
        scoreText.text = score.ToString();

=======
        player.transform.position = new Vector3(0, 3);
        score = 0;
        houseBabyDroped = 0;
        scoreText.text = score.ToString();
        houseBabyDropedText.text = score.ToString();
>>>>>>> Stashed changes
        playButton.SetActive(false);
        gameOver.SetActive(false);

        Time.timeScale = 1f;
        player.enabled=true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();
        for(int i =0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
<<<<<<< Updated upstream
=======

        GameObject[] fallBabyPrefabs = GameObject.FindGameObjectsWithTag("FallBaby");
        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(fallBabyPrefabs[i].gameObject);
        }
>>>>>>> Stashed changes
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

<<<<<<< Updated upstream

=======
    /*public void InstanciatePlayerTailBaby()
    {
        for(int i = 0; i < babycount; i++)
        {
            tailBabyArray[i] = Instantiate(tempPlayerTailBaby, player.transform.position, Quaternion.identity);
        }


    }*/

    //snake video
    /*public void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment);
    }*/

    //snake video
    /*public void FixedUpdate()
    {
        for(int i = _segments.Count-1; i>0; i--)
        {
            _segments[i].position = _segments[i - 1].position;
        }
    }*/

    /*public void Update()
    {
        for(int i = 0; i < tailBabyArray.Length; i++)
        {
            if (i == 0)
            {
                tempPlace = tailBabyArray[0].transform.position;
                tailBabyArray[0].transform.position = player.transform.position;
            }
            else
            {
                tailBabyArray[i].transform.position = tempPlace;
            }
        }
    }*/
>>>>>>> Stashed changes
}
