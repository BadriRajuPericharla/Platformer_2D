
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField]private GameObject MainMenu;
    public GameObject GameOver;
    [SerializeField]private GameObject Settings;
    [SerializeField]private MonoBehaviour movement;
    [SerializeField]private GameObject score;
    [SerializeField]private GameObject settingIcon;
    [SerializeField]private LevelCompletion insuff;
    [SerializeField]private GameObject mobilecontrollerPanel;
    [SerializeField] private GameObject LevelsPanel;
    [SerializeField] private Button level1Btn;
    [SerializeField] private Button level2Btn;
    [SerializeField] private Button level3Btn;
    [SerializeField]private Button level4Btn;
    private int level = 1;
    
    static bool SkipMenu=false;
    
    void Start()
    {
        if (Application.isMobilePlatform)
        {
            mobilecontrollerPanel.SetActive(true);
        }

        if (SkipMenu && MainMenu!=null)
        {
            MainMenu.SetActive(false);
            SkipMenu=false;
            movement.enabled=true;
        }
        else
        {
            if (MainMenu != null)
            {
                MainMenu.SetActive(true);
                movement.enabled=false;
            }
            
        }
       level = PlayerPrefs.GetInt("UnlockedLevel", 1);
        Debug.Log(level);
        if (level >= 2)
        {
            level2Btn.enabled = true;
            Image image = level2Btn.GetComponent<Image>();
            Color color = image.color;
            color.a = 1f;
            image.color = color;

        }
        if (level >= 3)
        {
            level3Btn.enabled = true;
            Image image = level3Btn.GetComponent<Image>();
            Color color = image.color;
            color.a = 1f;
            image.color = color;

        }
        if (level >= 4)
        {
            level4Btn.enabled = true;
            Image image = level4Btn.GetComponent<Image>();
            Color color = image.color;
            color.a = 1f;
            image.color = color;

        }
    }

    
    void Update()
    {
        
    }
    public void showMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Play()
    {
        SkipMenu=true;
        LevelsPanel.SetActive(true);
       
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Restart()
    {

        SkipMenu=true;
        AddManager.Instance.ShowRetryAd();
    }
    public void ShowSettings()
    {
        if (MainMenu != null)
        {
            MainMenu.SetActive(false);
        }
        movement.enabled = false;
        GameOver.SetActive(false);
        Settings.SetActive(true);
    }
    public void Home()
    {
        showMainMenu();
    }
    public void Next()
    {
        SkipMenu = true;
        movement.enabled = false;
        level = PlayerPrefs.GetInt("UnlockedLevel", 1);
        
        if (level < 5)
        {
            level++;
            PlayerPrefs.SetInt("UnlockedLevel", level);
            PlayerPrefs.Save();
        }
        if (level >= 2)
        {
            level2Btn.enabled = true;
            Image image = level2Btn.GetComponent<Image>();
            Color color = image.color;
            color.a = 1f;
            image.color = color;

        }
        if (level >= 3)
        {
            level3Btn.enabled = true;
            Image image = level3Btn.GetComponent<Image>();
            Color color = image.color;
            color.a = 1f;
            image.color = color;

        }
        if (level >= 4)
        {
            level4Btn.enabled = true;
            Image image = level4Btn.GetComponent<Image>();
            Color color = image.color;
            color.a = 1f;
            image.color = color;

        }
        
        LevelsPanel.SetActive(true);
    }
    public void Replay()
    {
        SceneManager.LoadScene(0);
    }
    public void Resume()
    {
        if (Application.isMobilePlatform)
        {
            mobilecontrollerPanel.SetActive(true);
        }
        Settings.SetActive(false);
        movement.enabled = true;
        insuff.Insufficient.SetActive(false);
    }
    public void Continue()
    {

        
        AddManager.Instance.ShowRewardedAd();
        
    }
    public void Level1()
    {
        SkipMenu = true;
        SceneManager.LoadScene(0);
    }
    public void Level2()
    {
        SkipMenu = true;
        SceneManager.LoadScene(1);
    }
    public void Level3()
    {
        SkipMenu = true;
        SceneManager.LoadScene(2);
    }
    public void Level4()
    {
        SkipMenu = true;
        SceneManager.LoadScene(3);
    }
    public void RevivePlayer()
    {
        movement.gameObject.transform.position = GameManager.instance.currentCheckPosition;
        movement.gameObject.SetActive(true);
        GameOver.SetActive(false);
    }



}
