using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject levelButtons;
    [SerializeField] private GameObject levelsToggleButton;
    [SerializeField] private GameObject darkPanel;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void NextLevel()
    {
        darkPanel.GetComponent<Image>().DOFade(1, 1).OnComplete(()=> { StartNextLevel(); });
    }

    public void StartNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        PlayerPrefs.SetInt("LevelCount", SceneManager.GetActiveScene().buildIndex + 1);
        levelsToggleButton.SetActive(true);

        darkPanel.GetComponent<Image>().DOFade(0, 1);
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
        else if (Input.GetKeyDown(KeyCode.M))
        {
            PlayerPrefs.DeleteAll();
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