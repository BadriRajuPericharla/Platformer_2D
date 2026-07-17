
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
       
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Restart()
    {

        SkipMenu=true;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        AddManager.Instance.ShowRetryAd();
    }
    public void ShowSettings()
    {
        if (MainMenu != null)
        {
            MainMenu.SetActive(false);
        }
        
        GameOver.SetActive(false);
        Settings.SetActive(true);
    }
    public void Home()
    {
        showMainMenu();
    }
    public void Next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
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
        insuff.Insufficient.SetActive(false);
    }
    public void Continue()
    {

        movement.gameObject.transform.position = GameManager.instance.currentCheckPosition;
        movement.gameObject.SetActive(true);
        GameOver.SetActive(false);
        AddManager.Instance.ShowRewardedAd();
        
    }
    


}
