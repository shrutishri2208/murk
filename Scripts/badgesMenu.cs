using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class badgesMenu : MonoBehaviour
{



    public Sprite[] completeSprite;
    public Sprite[] incompleteSprite;

    public TextMeshProUGUI achName;
    public TextMeshProUGUI achDescription;
    public TextMeshProUGUI achProgress;
    public Image progressBarWhite;
    public Image progressBarBlack;
    public Image progressBarGrey;

    public GameObject achPrize1;
    public GameObject achPrize2;
    public GameObject completed;


    public string[] achNames;


    string[] achDescriptions = new string[24] 
    {
        "COLLECT 50 STARS",
        "HIT THE WALL 20 TIMES",
        "COVER 15 METERS WITH 0 STARS",
        "COVER A TOTAL OF 100 METERS",
        "20 NEAR MISSES",
        "COLLECT EXACTLY 20 STARS",
        "COVER 50 METERS IN ONE RUN",
        "HIT THE ENEMY A 100 TIMES",
        "COLLECT 3 OR MORE BADGES IN ONE RUN",
        "RESURRECT 50 TIMES",
        "REACH AN AVERAGE DISTANCE OF 20 METERS",
        "PLAY OVER 50 GAMES",
        "COVER A TOTAL OF 500 METERS",
        "COVER 80 METERS IN ONE RUN",
        "BEAT YOUR OWN HIGH SCORE 10 TIMES",
        "COLLECT 5000 STARS",
        "COLLECT A TOTAL OF 15 BADGES",
        "COLLECT 20 REVIVES",
        "COVER A TOTAL OF  1000 METERS",
        "PLAY OVER 100 GAMES",
        "REACH AN AVERAGE DISTANCE OF 50 METERS",
        "UNLOCK ALL THE SUITS",
        "COVER A TOTAL OF 10000 METERS",
        "COLLECT 10000 STARS"
    };

    public Image[] achImages;

    public Image bottomSheetIcon;



    public TextMeshProUGUI totalRevivesText;


    float allTimeStars;
    float statStars;
    float allTimeDistance;
    float allTimeGames;
    float totalRevives;
    float enemyHit;
    float nearMiss;
    float wallHit;
    float allTimeBadges;
    float allTimeResurrect;
    float highScoreNo;
    float allTimeSuits;
    float statRevives;



    public void Start()
    {
        badgesMenuUpdates();
    }


    public void badgesMenuUpdates()
    {

        allTimeStars = PlayerPrefs.GetFloat("allTimeStars");
        statStars = PlayerPrefs.GetFloat("statStars");
        wallHit = PlayerPrefs.GetFloat("wallHit");
        nearMiss = PlayerPrefs.GetFloat("nearMiss");
        allTimeDistance = PlayerPrefs.GetFloat("allTimeDistance");
        enemyHit = PlayerPrefs.GetFloat("enemyHit");
        allTimeResurrect = PlayerPrefs.GetFloat("allTimeResurrect");
        allTimeGames = PlayerPrefs.GetFloat("allTimeGames");
        highScoreNo = PlayerPrefs.GetFloat("highScoreNo");
        allTimeBadges = PlayerPrefs.GetFloat("allTimeBadges");
        totalRevives = PlayerPrefs.GetFloat("totalRevives");
        statRevives = PlayerPrefs.GetFloat("statRevives");



        for (int i = 0; i < 24; i++)
        {
            if (PlayerPrefs.GetFloat("status" + i) == 1)
            {
                achImages[i].GetComponent<Image>().sprite = completeSprite[i];
            }
        }

        totalRevivesText.text = totalRevives.ToString("0");
    }


    public void menuTranstionSound()
    {
        FindObjectOfType<audioManager>().Play("menuTransition");

    }


    public void achMenu(int a)
    {
        allTimeSuits = PlayerPrefs.GetFloat("allTimeSuits");



        achName.text = achNames[a];
        achDescription.text = achDescriptions[a];



        if (PlayerPrefs.GetFloat("status" + a) == 1)
        {
            bottomSheetIcon.GetComponent<Image>().sprite = completeSprite[a];
        }
        else
        {
            bottomSheetIcon.GetComponent<Image>().sprite = incompleteSprite[a];
        }

        if (a == 0 && PlayerPrefs.GetFloat("status0") != 1)
        {
            achProgress.GetComponent<TextMeshProUGUI>().enabled = true;
            achProgress.text = allTimeStars.ToString() + "/50"; 
            progressBarWhite.enabled = true;
            progressBarBlack.enabled = true;
            progressBarGrey.enabled = true;
            progressBarWhite.fillAmount = allTimeStars / 50;
        }
        if (a == 1 && PlayerPrefs.GetFloat("status1") != 1)
        {
            achProgress.GetComponent<TextMeshProUGUI>().enabled = true;
            achProgress.text = wallHit.ToString() + "/20"; 
            progressBarWhite.enabled = true;
            progressBarBlack.enabled = true;
            progressBarGrey.enabled = true;
            progressBarWhite.fillAmount = wallHit / 20;

        }
        if (a == 3 && PlayerPrefs.GetFloat("status3") != 1)
        {
            achProgress.GetComponent<TextMeshProUGUI>().enabled = true;
            achProgress.text = Math.Round(allTimeDistance, 1).ToString() + "/100"; 
            progressBarWhite.enabled = true;
            progressBarBlack.enabled = true;
            progressBarGrey.enabled = true;
            progressBarWhite.fillAmount = allTimeDistance / 100;

        }
        if (a == 4 && PlayerPrefs.GetFloat("status4") != 1)
        {
            achProgress.GetComponent<TextMeshProUGUI>().enabled = true;
            achProgress.text = nearMiss.ToString() + "/20"; 
            progressBarBlack.enabled = true;
            progressBarGrey.enabled = true;
            progressBarWhite.fillAmount = nearMiss / 20;

        }
        if (a == 7 && PlayerPrefs.GetFloat("status7") != 1)
        {
            achProgress.GetComponent<TextMeshProUGUI>().enabled = true;
            achProgress.text = enemyHit.ToString() + "/100"; 
            progressBarWhite.enabled = true;
            progressBarBlack.enabled = true;
            progressBarGrey.enabled = true;
            progressBarWhite.fillAmount = enemyHit / 100;

        }
        if (a == 9 && PlayerPrefs.GetFloat("status9") != 1)
        {
            achProgress.GetComponent<TextMeshProUGUI>().enabled = true;
            achProgress.text = allTimeResurrect.ToString() + "/50"; 
            progressBarWhite.enabled = true;
            progressBarBlack.enabled = true;
            progressBarGrey.enabled = true;
            progressBarWhite.fillAmount = allTimeResurrect / 50;

        }
        if (a == 10 && PlayerPrefs.GetFloat("status10") != 1)
        {
            achProgress.GetComponent<TextMeshProUGUI>().enabled = true;
            if(allTimeGames == 0)
            {
                achProgress.text = "0/20"; 
                progressBarWhite.fillAmount = 0;

            }
            else
            {
                achProgress.text = Math.Round(allTimeDistance / allTimeGames, 1).ToString() + "/20"; 
                progressBarWhite.fillAmount = (allTimeDistance / allTimeGames) / 20;
            }
            progressBarWhite.enabled = true;
            progressBarBlack.enabled = true;
            progressBarGrey.enabled = true;

        }
        if (a == 11 && PlayerPrefs.GetFloat("status11") != 1)
        {
            achProgress.GetComponent<TextMeshProUGUI>().enabled = true;
            achProgress.text = allTimeGames.ToString() + "/50"; 
            progressBarWhite.enabled = true;
            progressBarBlack.enabled = true;
            progressBarGrey.enabled = true;
            progressBarWhite.fillAmount = allTimeGames / 50;

        }
        if (a == 12 && PlayerPrefs.GetFloat("status12") != 1)
        {
            achProgress.GetComponent<TextMeshProUGUI>().enabled = true;
            achProgress.text = Math.Round(allTimeDistance, 1).ToString() + "/500";  
            progressBarWhite.enabled = true;
            progressBarBlack.enabled = true;
            progressBarGrey.enabled = true;
            progressBarWhite.fillAmount = allTimeDistance / 500;

        }
        if (a == 14 && PlayerPrefs.GetFloat("status14") != 1)
        {
            achProgress.GetComponent<TextMeshProUGUI>().enabled = true;
            achProgress.text = highScoreNo.ToString() + "/10";  
            progressBarWhite.enabled = true;
            progressBarBlack.enabled = true;
            progressBarGrey.enabled = true;
            progressBarWhite.fillAmount = highScoreNo / 10;
        }
        if (a == 15 && PlayerPrefs.GetFloat("status15") != 1)
        {
            achProgress.GetComponent<TextMeshProUGUI>().enabled = true;
            achProgress.text = statStars.ToString() + "/5000";  
            progressBarWhite.enabled = true;
            progressBarBlack.enabled = true;
            progressBarGrey.enabled = true;
            progressBarWhite.fillAmount = statStars / 5000;

        }
        if (a == 16 && PlayerPrefs.GetFloat("status16") != 1)
        {
            achProgress.GetComponent<TextMeshProUGUI>().enabled = true;
            achProgress.text = allTimeBadges.ToString() + "/15"; 
            progressBarWhite.enabled = true;
            progressBarBlack.enabled = true;
            progressBarGrey.enabled = true;
            progressBarWhite.fillAmount = allTimeBadges / 15;

        }
        if (a == 17 && PlayerPrefs.GetFloat("status17") != 1)
        {
            achProgress.GetComponent<TextMeshProUGUI>().enabled = true;
            achProgress.text = statRevives.ToString() + "/20"; 
            progressBarWhite.enabled = true;
            progressBarBlack.enabled = true;
            progressBarGrey.enabled = true;
            progressBarWhite.fillAmount = statRevives / 20;

        }
        if (a == 18 && PlayerPrefs.GetFloat("status18") != 1)
        {
            achProgress.GetComponent<TextMeshProUGUI>().enabled = true;
            achProgress.text = Math.Round(allTimeDistance, 1).ToString() + "/1000";  
            progressBarWhite.enabled = true;
            progressBarBlack.enabled = true;
            progressBarGrey.enabled = true;
            progressBarWhite.fillAmount = allTimeDistance / 1000;
        }
        if (a == 19 && PlayerPrefs.GetFloat("status19") != 1)
        {
            achProgress.GetComponent<TextMeshProUGUI>().enabled = true;
            achProgress.text = allTimeGames.ToString() + "/100";
            progressBarWhite.enabled = true;
            progressBarBlack.enabled = true;
            progressBarGrey.enabled = true;
            progressBarWhite.fillAmount = allTimeGames / 100;

        }
        if (a == 20 && PlayerPrefs.GetFloat("status20") != 1)
        {
            achProgress.GetComponent<TextMeshProUGUI>().enabled = true;
            if (allTimeGames == 0)
            {
                achProgress.text = "0/50"; 
                progressBarWhite.fillAmount = 0;

            }
            else
            {
                achProgress.text = Math.Round(allTimeDistance / allTimeGames, 1).ToString() + "/50"; 
                progressBarWhite.fillAmount = (allTimeDistance / allTimeGames) / 50;
            }
            progressBarWhite.enabled = true;
            progressBarBlack.enabled = true;
            progressBarGrey.enabled = true;

        }
        if (a == 21 && PlayerPrefs.GetFloat("status21") != 1)
        {
            achProgress.GetComponent<TextMeshProUGUI>().enabled = true;
            achProgress.text = allTimeSuits.ToString("0") + "/11"; 
            progressBarWhite.enabled = true;
            progressBarBlack.enabled = true;
            progressBarGrey.enabled = true;
            progressBarWhite.fillAmount = allTimeSuits / 11;

        }
        if (a == 22 && PlayerPrefs.GetFloat("status22") != 1)
        {
            achProgress.GetComponent<TextMeshProUGUI>().enabled = true;
            achProgress.text = Math.Round(allTimeDistance, 1).ToString() + "/10000";  
            progressBarWhite.enabled = true;
            progressBarBlack.enabled = true;
            progressBarGrey.enabled = true;
            progressBarWhite.fillAmount = allTimeDistance / 10000;

        }
        if (a == 23 && PlayerPrefs.GetFloat("status23") != 1)
        {
            achProgress.GetComponent<TextMeshProUGUI>().enabled = true;
            achProgress.text = statStars.ToString() + "/10000";  
            progressBarWhite.enabled = true;
            progressBarBlack.enabled = true;
            progressBarGrey.enabled = true;
            progressBarWhite.fillAmount = statStars / 10000;

        }


        if (PlayerPrefs.GetFloat("status" + a) == 1)
        {
            achProgress.GetComponent<TextMeshProUGUI>().enabled = false;
            achProgress.text = "";
            progressBarWhite.enabled = false;
            progressBarBlack.enabled = false;
            progressBarGrey.enabled = false;
            achPrize1.SetActive(false);
            achPrize2.SetActive(false);
            completed.SetActive(true);
        }
        else if (a == 2 || a == 5 || a == 6 || a == 8 || a == 13)
        {
            achPrize2.SetActive(true);
            achPrize1.SetActive(false);
            achProgress.GetComponent<TextMeshProUGUI>().enabled = false;
            achProgress.text = "";
            progressBarWhite.enabled = false;
            progressBarBlack.enabled = false;
            progressBarGrey.enabled = false;
            completed.SetActive(false);
        }
        else
        {
            achPrize1.SetActive(true);
            achPrize2.SetActive(false);
            completed.SetActive(false);
        }
    }


}