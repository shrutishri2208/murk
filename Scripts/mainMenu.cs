using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainMenu : MonoBehaviour
{

    int moonCount;


    public GameObject moon;

    public Sprite[] moonPhases;

    public GameObject howToPlayMenu;
    public GameObject exitMenu;

    public GameObject firstScreen;


    void Start()
    {


        Time.timeScale = 1f;


        moonCount = PlayerPrefs.GetInt("moonCount");


        int m = moonCount % 7;
        moon.GetComponent<Image>().sprite = moonPhases[m];

        moonCount += 1;
        PlayerPrefs.SetInt("moonCount", moonCount);

        
    }

    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                exitMenu.SetActive(true);
                return;
            }


        }

    }



    public void playGame()
    {
        FindObjectOfType<audioManager>().Play("click");
        if(PlayerPrefs.GetFloat("howToPlay") == 0f)
        {
            howToPlayMenu.GetComponent<Animator>().Play("howToPlayOpen");
            PlayerPrefs.SetFloat("howToPlay", 1f);
        }
        else
        {
            firstScreen.GetComponent<Animator>().Play("mainMenu_firstScreenClose");
            SceneManager.LoadSceneAsync("world");
        }
    }

    public void menuTransitionSound()
    {
        FindObjectOfType<audioManager>().Play("menuTransition");


    }

    public void setHowToTrue()
    {
        PlayerPrefs.SetFloat("howToPlay", 1f);
    }


    public void loadPractise()
    {
        FindObjectOfType<audioManager>().Play("click");

        SceneManager.LoadSceneAsync("practise");
    }

    public void exitGame()
    {
        Application.Quit();
    }
}