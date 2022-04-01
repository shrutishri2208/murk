using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;


public class pauseMenu : MonoBehaviour
{

    float levelDistance;
    float levelStars;
    float totalRevives;
    float allTimeResurrect;



    public TextMeshProUGUI starDisplay;
    public TextMeshProUGUI distanceDisplay;
    public TextMeshProUGUI totalRevivesText;

    public Image vibrateImage;
    public Image soundImage;
    public Image musicImage;


    public Sprite[] vibrateSprites;
    public Sprite[] soundSprites;
    public Sprite[] musicSprites;

    public audioManager am;
    public audioManager2 am2;

    float allTimeGames;

    private void Start()
    {
        if (PlayerPrefs.GetInt("isVibrateOff") == 0)
        {
            vibrateImage.GetComponent<Image>().sprite = vibrateSprites[0];
        }
        else
        {
            vibrateImage.GetComponent<Image>().sprite = vibrateSprites[1];
        }



        if (PlayerPrefs.GetInt("isSoundOff") == 0)
        {
            soundImage.GetComponent<Image>().sprite = soundSprites[0];
        }
        else
        {
            soundImage.GetComponent<Image>().sprite = soundSprites[1];
        }



        if (PlayerPrefs.GetInt("isMusicOff") == 0)
        {
            musicImage.GetComponent<Image>().sprite = musicSprites[0];
        }
        else
        {
            musicImage.GetComponent<Image>().sprite = musicSprites[1];
        }

    }

    public void Update()
    {
        levelDistance = PlayerPrefs.GetFloat("levelDistance");
        levelStars = PlayerPrefs.GetFloat("levelStars");
        totalRevives = PlayerPrefs.GetFloat("totalRevives");

        starDisplay.text = levelStars.ToString();
        distanceDisplay.text = Math.Round(levelDistance, 1).ToString();
        totalRevivesText.text = totalRevives.ToString("0");
    }

    public void sound()
    {
        am.Play("click");

        if (PlayerPrefs.GetInt("isSoundOff") == 0)
        {
            PlayerPrefs.SetInt("isSoundOff", 1);
            soundImage.GetComponent<Image>().sprite = soundSprites[1];
            am.soundOff();
        }
        else
        {
            PlayerPrefs.SetInt("isSoundOff", 0);
            soundImage.GetComponent<Image>().sprite = soundSprites[0];
            am.soundOn();
        }
    }


    public void music()
    {
        am.Play("click");

        if (PlayerPrefs.GetInt("isMusicOff") == 0)
        {
            PlayerPrefs.SetInt("isMusicOff", 1);
            musicImage.GetComponent<Image>().sprite = musicSprites[1];
            am2.musicOff();

        }
        else
        {
            PlayerPrefs.SetInt("isMusicOff", 0);
            musicImage.GetComponent<Image>().sprite = musicSprites[0];
            am2.musicOn();
        }
    }

    public void vibrate()
    {
        am.Play("click");

        if (PlayerPrefs.GetInt("isVibrateOff") == 0)
        {
            PlayerPrefs.SetInt("isVibrateOff", 1);
            vibrateImage.GetComponent<Image>().sprite = vibrateSprites[1];
        }
        else
        {
            PlayerPrefs.SetInt("isVibrateOff", 0);
            vibrateImage.GetComponent<Image>().sprite = vibrateSprites[0];
        }
    }

    public void resume()
    {
        Time.timeScale = 1f;
        FindObjectOfType<audioManager>().Play("menuTransition");
    }

    public void quit()
    {
        //Time.timeScale = 1f;
        FindObjectOfType<audioManager>().Play("click");

        SceneManager.LoadSceneAsync("mainMenu");

        allTimeGames = PlayerPrefs.GetFloat("allTimeGames");
        allTimeGames -= 1;
        PlayerPrefs.SetFloat("allTimeGames", allTimeGames);


        if (FindObjectOfType<gameManager>().revivalOnce == true)
        {
            allTimeResurrect = PlayerPrefs.GetFloat("allTimeResurrect");
            allTimeResurrect -= 1;
            PlayerPrefs.SetFloat("allTimeResurrect", allTimeResurrect);

            totalRevives = PlayerPrefs.GetFloat("totalRevives");
            totalRevives += 1;
            PlayerPrefs.SetFloat("totalRevives", totalRevives);

        }
        
    }


}
