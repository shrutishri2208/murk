using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class gameOverMenu : MonoBehaviour
{

    float allTimeStars;
    float statStars;
    float allTimeDistance;
    float allTimeGames;
    float totalRevives;
    float enemyHit;
    float nearMiss;
    float levelStars;
    float levelDistance;
    float wallHit;
    float allTimeBadges;
    float allTimeResurrect;
    float highScoreNo;
    float levelBadges = 0;
    float allTimeSuits;
    float statRevives;
    float maxHeight;
    float maxStars;

    float beforeR;
    float afterR;

    float multiplier;

    public TextMeshProUGUI achOverText;
    public TextMeshProUGUI achOverText1;
    public TextMeshProUGUI achOverText2;
    public TextMeshProUGUI achOverText3;
    public TextMeshProUGUI achOverText4;


    public TextMeshProUGUI totalRevivesText;
    public TextMeshProUGUI totalDistanceNumber;
    public TextMeshProUGUI totalStarsNumber;

    public TextMeshProUGUI multiplierText;
    public GameObject multiplierImage;

    public GameObject badgesGroup;

    public TextMeshProUGUI gameOverText;

    string[] achs = new string[25] 
    {   " ",
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

    string[] gameOText = new string[5]
    {
        "YOU ARE NOT DEAD YET!",
        "DO NOT GIVE UP!",
        "YOU HAVE THE POWER!",
        "PICK YOURSELF UP!",
        "ONE STEP AT A TIME!"
    };


    public GameObject[] badges;

    int[] array;
    float r;





    public void Start()
    {
        FindObjectOfType<gameManager>().updateStats();

        levelBadges = 0;

        allTimeStars = PlayerPrefs.GetFloat("allTimeStars");
        statStars = PlayerPrefs.GetFloat("statStars");
        wallHit = PlayerPrefs.GetFloat("wallHit");
        nearMiss = PlayerPrefs.GetFloat("nearMiss");
        levelStars = PlayerPrefs.GetFloat("levelStars");
        allTimeDistance = PlayerPrefs.GetFloat("allTimeDistance");
        levelDistance = PlayerPrefs.GetFloat("levelDistance");
        enemyHit = PlayerPrefs.GetFloat("enemyHit");
        allTimeGames = PlayerPrefs.GetFloat("allTimeGames");
        highScoreNo = PlayerPrefs.GetFloat("highScoreNo");
        allTimeBadges = PlayerPrefs.GetFloat("allTimeBadges");
        allTimeResurrect = PlayerPrefs.GetFloat("allTimeResurrect");
        allTimeSuits = PlayerPrefs.GetFloat("allTimeSuits");
        totalRevives = PlayerPrefs.GetFloat("totalRevives");
        statRevives = PlayerPrefs.GetFloat("statRevives");
        multiplier = PlayerPrefs.GetFloat("multiplier");
        maxHeight = PlayerPrefs.GetFloat("maxHeight");
        maxStars = PlayerPrefs.GetFloat("maxStars");


        totalDistanceNumber.text = Math.Round(levelDistance, 1).ToString();
        totalStarsNumber.text = levelStars.ToString("0");

        multiplierText.text = multiplier.ToString() + "x";

        int index = UnityEngine.Random.Range(0, 5);
        gameOverText.text = gameOText[index];

        if(levelDistance < maxHeight)
        {
            Invoke("starUpdate", 1f);
        }


        if(levelStars > maxStars)
        {
            maxStars = levelStars;
            PlayerPrefs.SetFloat("maxStars", maxStars);
        }


        beforeR = PlayerPrefs.GetFloat("totalRevives");

        if (allTimeStars >= 50 && PlayerPrefs.GetFloat("status0") != 1)
        {
            //COLLECT 50 STARS
            PlayerPrefs.SetFloat("status0", 1f);
            levelBadges += 1;
            allTimeBadges += 1;
            PlayerPrefs.SetFloat("allTimeBadges", allTimeBadges);
            totalRevives += 2;
            PlayerPrefs.SetFloat("totalRevives", totalRevives);
        }
        if (wallHit >= 20  && PlayerPrefs.GetFloat("status1") != 1)
        {
            //HIT THE WALL 20 TIMES
            PlayerPrefs.SetFloat("status1", 1f);
            levelBadges += 1;
            allTimeBadges += 1;
            PlayerPrefs.SetFloat("allTimeBadges", allTimeBadges);
            totalRevives += 2;
            PlayerPrefs.SetFloat("totalRevives", totalRevives);

        }
        if (levelDistance >= 15f && (levelStars == 0) && PlayerPrefs.GetFloat("status2") != 1)
        {
            //COVER 15 METERS WITH 0 STARS
            PlayerPrefs.SetFloat("status2", 1f);
            levelBadges += 1;
            allTimeBadges += 1;
            PlayerPrefs.SetFloat("allTimeBadges", allTimeBadges);
            totalRevives += 2;
            PlayerPrefs.SetFloat("totalRevives", totalRevives);

        }
        if (allTimeDistance >= 100f && PlayerPrefs.GetFloat("status3") != 1)
        {
            //COVER A TOTAL 100 METERS
            PlayerPrefs.SetFloat("status3", 1f);
            levelBadges += 1;
            allTimeBadges += 1;
            PlayerPrefs.SetFloat("allTimeBadges", allTimeBadges);
            totalRevives += 2;
            PlayerPrefs.SetFloat("totalRevives", totalRevives);

        }
        if (nearMiss >= 20 && PlayerPrefs.GetFloat("status4") != 1)
        {
            //20 NEAR MISSES
            PlayerPrefs.SetFloat("status4", 1f);
            levelBadges += 1;
            allTimeBadges += 1;
            PlayerPrefs.SetFloat("allTimeBadges", allTimeBadges);
            totalRevives += 2;
            PlayerPrefs.SetFloat("totalRevives", totalRevives);

        }
        if (levelStars == 20 && PlayerPrefs.GetFloat("status5") != 1)
        {
            //COLLECT EXACTLY 20 STARS
            PlayerPrefs.SetFloat("status5", 1f);
            levelBadges += 1;
            allTimeBadges += 1;
            PlayerPrefs.SetFloat("allTimeBadges", allTimeBadges);
            totalRevives += 2;
            PlayerPrefs.SetFloat("totalRevives", totalRevives);

        }
        if (levelDistance >= 50f && PlayerPrefs.GetFloat("status6") != 1)
        {
            //COVER 50 METERS IN ONE RUN
            PlayerPrefs.SetFloat("status6", 1f);
            levelBadges += 1;
            allTimeBadges += 1;
            PlayerPrefs.SetFloat("allTimeBadges", allTimeBadges);
            totalRevives += 2;
            PlayerPrefs.SetFloat("totalRevives", totalRevives);

        }
        if (enemyHit >= 100 && PlayerPrefs.GetFloat("status7") != 1)
        {
            //HIT THE ENEMY 100 TIMES
            PlayerPrefs.SetFloat("status7", 1f);
            levelBadges += 1;
            allTimeBadges += 1;
            PlayerPrefs.SetFloat("allTimeBadges", allTimeBadges);
            totalRevives += 2;
            PlayerPrefs.SetFloat("totalRevives", totalRevives);

        }

        if (allTimeResurrect >= 50 && PlayerPrefs.GetFloat("status9") != 1)
        {
            //RESURRECT 50 TIMES
            PlayerPrefs.SetFloat("status9", 1f);
            levelBadges += 1;
            allTimeBadges += 1;
            PlayerPrefs.SetFloat("allTimeBadges", allTimeBadges);
            totalRevives += 2;
            PlayerPrefs.SetFloat("totalRevives", totalRevives);

        }
        if (Math.Round(allTimeDistance / allTimeGames, 1) >= 20f && PlayerPrefs.GetFloat("status10") != 1)
        {
            //REACH AN AVERAGE DISTANCE OF 50 METERS
            PlayerPrefs.SetFloat("status10", 1f);
            levelBadges += 1;
            allTimeBadges += 1;
            PlayerPrefs.SetFloat("allTimeBadges", allTimeBadges);
            totalRevives += 2;
            PlayerPrefs.SetFloat("totalRevives", totalRevives);

        }
        if (allTimeGames >= 50 && PlayerPrefs.GetFloat("status11") != 1)
        {
            //PLAY OVER 50 GAMES
            PlayerPrefs.SetFloat("status11", 1f);
            levelBadges += 1;
            allTimeBadges += 1;
            PlayerPrefs.SetFloat("allTimeBadges", allTimeBadges);
            totalRevives += 2;
            PlayerPrefs.SetFloat("totalRevives", totalRevives);

        }
        if (allTimeDistance >= 500f && PlayerPrefs.GetFloat("status12") != 1)
        {
            //COVER A TOTAL 500 METERS
            PlayerPrefs.SetFloat("status12", 1f);
            levelBadges += 1;
            allTimeBadges += 1;
            PlayerPrefs.SetFloat("allTimeBadges", allTimeBadges);
            totalRevives += 2;
            PlayerPrefs.SetFloat("totalRevives", totalRevives);

        }
        if (levelDistance >= 80f && PlayerPrefs.GetFloat("status13") != 1)
        {
            //COVER 80 METERS IN ONE RUN
            PlayerPrefs.SetFloat("status13", 1f);
            levelBadges += 1;
            allTimeBadges += 1;
            PlayerPrefs.SetFloat("allTimeBadges", allTimeBadges);
            totalRevives += 2;
            PlayerPrefs.SetFloat("totalRevives", totalRevives);

        }
        if (highScoreNo >= 10 && PlayerPrefs.GetFloat("status14") != 1)
        {
            //BEAT YOUR OWN HIGH SCORE 10 TIMES
            PlayerPrefs.SetFloat("status14", 1f);
            levelBadges += 1;
            allTimeBadges += 1;
            PlayerPrefs.SetFloat("allTimeBadges", allTimeBadges);
            totalRevives += 2;
            PlayerPrefs.SetFloat("totalRevives", totalRevives);

        }
        if (statStars >= 5000 && PlayerPrefs.GetFloat("status15") != 1)
        {
            //COLLECT 5000 STARS
            PlayerPrefs.SetFloat("status15", 1f);
            levelBadges += 1;
            allTimeBadges += 1;
            PlayerPrefs.SetFloat("allTimeBadges", allTimeBadges);
            totalRevives += 2;
            PlayerPrefs.SetFloat("totalRevives", totalRevives);

        }

        if (statRevives >= 20 && PlayerPrefs.GetFloat("status17") != 1)
        {
            //COLLECT 20 REVIVES
            PlayerPrefs.SetFloat("status17", 1f);
            levelBadges += 1;
            allTimeBadges += 1;
            PlayerPrefs.SetFloat("allTimeBadges", allTimeBadges);
            totalRevives += 2;
            PlayerPrefs.SetFloat("totalRevives", totalRevives);

        }
        if (allTimeDistance >= 1000f && PlayerPrefs.GetFloat("status18") != 1)
        {
            //COVER A TOTAL 1000 METERS
            PlayerPrefs.SetFloat("status18", 1f);
            levelBadges += 1;
            allTimeBadges += 1;
            PlayerPrefs.SetFloat("allTimeBadges", allTimeBadges);
            totalRevives += 2;
            PlayerPrefs.SetFloat("totalRevives", totalRevives);

        }
        if (allTimeGames >= 100 && PlayerPrefs.GetFloat("status19") != 1)
        {
            //PLAY OVER 100 GAMES
            PlayerPrefs.SetFloat("status19", 1f);
            levelBadges += 1;
            allTimeBadges += 1;
            PlayerPrefs.SetFloat("allTimeBadges", allTimeBadges);
            totalRevives += 2;
            PlayerPrefs.SetFloat("totalRevives", totalRevives);

        }
        if (Math.Round(allTimeDistance / allTimeGames, 1) >= 50f && PlayerPrefs.GetFloat("status20") != 1)
        {
            //REACH AN AVERAGE DISTANCE OF 100 METERS
            PlayerPrefs.SetFloat("status20", 1f);
            levelBadges += 1;
            allTimeBadges += 1;
            PlayerPrefs.SetFloat("allTimeBadges", allTimeBadges);
            totalRevives += 2;
            PlayerPrefs.SetFloat("totalRevives", totalRevives);

        }
        if (allTimeSuits == 11 && PlayerPrefs.GetFloat("status21") != 1)
        {
            //UNLOCK ALL THE SUITS
            PlayerPrefs.SetFloat("status21", 1f);
            levelBadges += 1;
            allTimeBadges += 1;
            PlayerPrefs.SetFloat("allTimeBadges", allTimeBadges);
            totalRevives += 2;
            PlayerPrefs.SetFloat("totalRevives", totalRevives);

        }
        if (allTimeDistance >= 10000f && PlayerPrefs.GetFloat("status22") != 1)
        {
            //COVER A TOTAL 10000 METERS
            PlayerPrefs.SetFloat("status22", 1f);
            levelBadges += 1;
            allTimeBadges += 1;
            PlayerPrefs.SetFloat("allTimeBadges", allTimeBadges);
            totalRevives += 2;
            PlayerPrefs.SetFloat("totalRevives", totalRevives);

        }
        if (statStars >= 10000 && PlayerPrefs.GetFloat("status23") != 1)
        {
            //COLLECT 10000 STARS
            PlayerPrefs.SetFloat("status23", 1f);
            levelBadges += 1;
            allTimeBadges += 1;
            PlayerPrefs.SetFloat("allTimeBadges", allTimeBadges);
            totalRevives += 2;
            PlayerPrefs.SetFloat("totalRevives", totalRevives);

        }
        if (allTimeBadges >= 15 && PlayerPrefs.GetFloat("status16") != 1)
        {
            //COMPLETE A TOTAL OF 15 ACHIEVEMENTS
            PlayerPrefs.SetFloat("status16", 1f);
            levelBadges += 1;
            allTimeBadges += 1;
            PlayerPrefs.SetFloat("allTimeBadges", allTimeBadges);
            totalRevives += 2;
            PlayerPrefs.SetFloat("totalRevives", totalRevives);

        }
        if (levelBadges >= 3 && PlayerPrefs.GetFloat("status8") != 1)
        {
            //COMPLETE 3 OR MORE ACHIEVEMENTS IN ONE RUN
            PlayerPrefs.SetFloat("status8", 1f);
            levelBadges += 1;
            allTimeBadges += 1;
            PlayerPrefs.SetFloat("allTimeBadges", allTimeBadges);
            totalRevives += 2;
            PlayerPrefs.SetFloat("totalRevives", totalRevives);

        }

        if (allTimeBadges >= 15 && PlayerPrefs.GetFloat("status16") != 1)
        {
            //COMPLETE A TOTAL OF 15 ACHIEVEMENTS
            PlayerPrefs.SetFloat("status16", 1f);
            levelBadges += 1;
            allTimeBadges += 1;
            PlayerPrefs.SetFloat("allTimeBadges", allTimeBadges);
            totalRevives += 2;
            PlayerPrefs.SetFloat("totalRevives", totalRevives);

        }



        totalRevivesText.text = beforeR.ToString("0");

        array = new int[24];


        array[0] = 0;


        for (int j = 1; j <= levelBadges; j++)
        {
            for (int i = array[j - 1] + 1; i <= 24; i++)
            {
                if (PlayerPrefs.GetFloat("status" + (i - 1)) == 1 && PlayerPrefs.GetFloat("once" + (i - 1)) != 1)
                {
                    array[j] = i;
                    PlayerPrefs.SetFloat("once" + (i - 1), 1f);
                    break;
                }
            }
        }

       

    }
    public void starUpdate()
    {
        multiplierImage.SetActive(true);
        totalStarsNumber.text = (levelStars * multiplier).ToString("0");
        totalStarsNumber.GetComponent<Animator>().Play("gameOverMenu_totalStarsNumbers");

        Invoke("badgesUpdate", 1f);
    }

    public void badgesUpdate()
    {
        badgesGroup.SetActive(true);

        for (int a = 0; a < levelBadges && a <= 4; a++)
        {
            badges[a].SetActive(true);
        }


        achOverText.text = achs[array[1]];

        achOverText1.text = achs[array[2]];

        achOverText2.text = achs[array[3]];

        achOverText3.text = achs[array[4]];

        achOverText4.text = achs[array[5]];



    }


    public void revivesUpdate()
    {
        if(beforeR < totalRevives)
        {
            beforeR += 2;
            totalRevivesText.text = beforeR.ToString("0");
            FindObjectOfType<audioManager>().Play("reward");

        }
    }

    public void replay()
    {
        FindObjectOfType<audioManager>().Play("click");

        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        //SceneManager.LoadScene("world");
    }


    public void mainMenu()
    {
        FindObjectOfType<audioManager>().Play("click");

        SceneManager.LoadSceneAsync("mainMenu");
    }







}