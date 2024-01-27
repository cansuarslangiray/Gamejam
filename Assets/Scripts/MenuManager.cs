using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject levelButtons;
    [SerializeField] private GameObject levelsToggleButton;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        PlayerPrefs.SetInt("LevelCount", SceneManager.GetActiveScene().buildIndex + 1); 
        levelsToggleButton.SetActive(true);
    }

    public void SelectLevels()
    {
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        var unlockedLevels = PlayerPrefs.GetInt("LevelCount", 1);
        for (int i = 0; i < 4; i++)
        {
            if (i < unlockedLevels)
            {
                levelButtons.transform.GetChild(i).GetComponent<Button>().interactable = true;
            }

            if (!levelButtons.transform.GetChild(i).gameObject.activeSelf)
            {
                levelButtons.transform.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                levelButtons.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            NextLevel();
        }
    }

    public void LoadDesiredLevel(int levelIndex)
    {
        for (int i = 0; i < 4; i++)
        {
            levelButtons.transform.GetChild(i).gameObject.SetActive(false);
        }

        Time.timeScale = 1;
        SceneManager.LoadScene(levelIndex);
    }
}