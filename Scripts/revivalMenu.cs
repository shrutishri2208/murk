using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class revivalMenu : MonoBehaviour
{

    float totalRevives;
    float levelDistance;
    float levelStars;

    public TextMeshProUGUI totalRevivesText;
    public TextMeshProUGUI distanceDisplay;
    public TextMeshProUGUI starDisplay;

    public TextMeshProUGUI timerText;
    float timer = 5f;
    public Image timerWhite;

    public GameObject revivalMenuUI;
    public GameObject highReviveMenuUI;
    public GameObject highGameOverMenuUI;
    public GameObject gameOverMenuUI;



    public void Start()
    {
        Time.timeScale = 0f;
        totalRevives = PlayerPrefs.GetFloat("totalRevives");
        levelDistance = PlayerPrefs.GetFloat("levelDistance");
        levelStars = PlayerPrefs.GetFloat("levelStars");



        totalRevivesText.text = totalRevives.ToString();
        distanceDisplay.text = Math.Round(levelDistance, 1).ToString();
        starDisplay.text = levelStars.ToString("0");



    }

    public void revive()
    {

        FindObjectOfType<audioManager>().Play("click");

        FindObjectOfType<gameManager>().revive();
    }

    public void reviveNo()
    {
        FindObjectOfType<audioManager>().Play("click");

        FindObjectOfType<gameManager>().noRevival();
    }


    private void Update()
    {

        timerText.text = timer.ToString("0");
        timer -= Time.unscaledDeltaTime;

        timerWhite.GetComponent<Image>().fillAmount = timer / 5f;


        if(timer <=0)
        {
            Time.timeScale = 1f;
            if (highReviveMenuUI.activeSelf == true)
            {
                highReviveMenuUI.SetActive(false);
                highGameOverMenuUI.SetActive(true);
            }
            if (revivalMenuUI.activeSelf == true)
            {
                revivalMenuUI.SetActive(false);
                gameOverMenuUI.SetActive(true);
            }
        }
    }




}