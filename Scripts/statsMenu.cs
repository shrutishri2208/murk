using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class statsMenu : MonoBehaviour
{

    public TextMeshProUGUI totalGames;
    public TextMeshProUGUI totalStars;
    public TextMeshProUGUI totalDistance;
    public TextMeshProUGUI totalRevivesText;
    public TextMeshProUGUI highScoreDistance;
    public TextMeshProUGUI highScoreStar;

    float allTimeStars;
    float allTimeDistance;
    float allTimeGames;
    float totalRevives;
    float maxHeight;
    float maxStars;


    void Start()
    {
        statsMenuUpdate();
    }


    public void statsMenuUpdate()
    {
        allTimeStars = PlayerPrefs.GetFloat("allTimeStars");
        allTimeDistance = PlayerPrefs.GetFloat("allTimeDistance");
        allTimeGames = PlayerPrefs.GetFloat("allTimeGames");
        totalRevives = PlayerPrefs.GetFloat("totalRevives");
        maxHeight = PlayerPrefs.GetFloat("maxHeight");
        maxStars = PlayerPrefs.GetFloat("maxStars");

        totalStars.text = allTimeStars.ToString("0");
        totalDistance.text = Math.Round(allTimeDistance, 1).ToString();
        totalGames.text = allTimeGames.ToString("0");
        totalRevivesText.text = totalRevives.ToString("0");
        highScoreDistance.text = Math.Round(maxHeight, 1).ToString();
        highScoreStar.text = maxStars.ToString("0");

    }


    public void restoreProgress()
    {
        PlayerPrefs.DeleteAll();

        SceneManager.LoadScene("mainMenu");
    }


    public void menuTransitionSound()
    {
        FindObjectOfType<audioManager>().Play("menuTransition");

    }
}