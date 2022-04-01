using TMPro;
using UnityEngine;
using System;


public class gameManager : MonoBehaviour
{
    public Rigidbody2D player;
    public GameObject playerStartImage;




    public TextMeshProUGUI starNumber;

    public Sprite deadSprite;
    playerMovement playerMovement;


    Vector2 fall;
    int arrIndex;



    float star;
    float life = 1;
    float levelDistance;
    float maxHeight;
    float totalRevives;
    float nearMiss;
    float allTimeResurrect;
    float allTimeStars;
    float statStars;
    float allTimeDistance;
    float allTimeGames;
    float wallHit;




    public bool revivalOnce;

    float multiplier;

    public GameObject nearMissText;

    public Sprite[] choiceSprites;
    int nowPlaying;





    public GameObject revivalMenuUI;
    public GameObject highReviveMenuUI;
    public GameObject highGameOverMenuUI;
    public GameObject gameOverMenuUI;
    void Start()
    {
        playerMovement = FindObjectOfType<playerMovement>();
        star = 0;
        fall = new Vector2(0f, -60f);


        arrIndex = PlayerPrefs.GetInt("arrayIndex");


        PlayerPrefs.SetFloat("levelStars", 0f);
        totalRevives = PlayerPrefs.GetFloat("totalRevives");

        PlayerPrefs.SetFloat("levelDistance", 0f);

        allTimeGames = PlayerPrefs.GetFloat("allTimeGames");
        allTimeGames += 1;
        PlayerPrefs.SetFloat("allTimeGames", allTimeGames);


        nowPlaying = PlayerPrefs.GetInt("nowPlaying");
        playerStartImage.GetComponent<SpriteRenderer>().sprite = choiceSprites[nowPlaying];
        player.GetComponent<SpriteRenderer>().sprite = choiceSprites[nowPlaying];


    }

    private void Update()
    {
        maxHeight = PlayerPrefs.GetFloat("maxHeight");

    }
    
    public void wallIncrement()
    {
        wallHit = PlayerPrefs.GetFloat("wallHit");
        wallHit = wallHit + 1;
        PlayerPrefs.SetFloat("wallHit", wallHit);

    }



    public void starIncrement()
    {
        star += 1;
        starNumber.text = star.ToString();
        PlayerPrefs.SetFloat("levelStars", star);
    }


    public void lifeDecrement()
    {
        life --;
        if (life == 0)
        {
            Time.timeScale = 1;
            deadAnimations();
            Invoke("gameOver", 1f);

        }

    }

    public void deadAnimations()
    {
        playerMovement.enabled = false;
        player.GetComponent<SpriteRenderer>().sprite = deadSprite;
        player.GetComponent<Animator>().Play("player_dead");
        player.GetComponent<Collider2D>().enabled = false;
        player.AddForce(fall);
        return;
    }

    public void gameOver()
    {
        
        levelDistance = PlayerPrefs.GetFloat("levelDistance");


        if (totalRevives > 0 && revivalOnce == false)
        {
            if (levelDistance > maxHeight)
            {
                //R+G+H
                PlayerPrefs.SetFloat("maxHeight", levelDistance);
                highReviveMenuUI.SetActive(true);
            }
            else
            {
                //R+G
                revivalMenuUI.SetActive(true);
            }
        }
        else if (levelDistance > maxHeight)
        {
            //H+G
            PlayerPrefs.SetFloat("maxHeight", levelDistance);
            highGameOverMenuUI.SetActive(true);

        }
        else
        {
            //G
            gameOverMenuUI.SetActive(true);

        }

    }


    

    public void updateStats()
    {

        allTimeDistance = PlayerPrefs.GetFloat("allTimeDistance");
        allTimeDistance += levelDistance;
        PlayerPrefs.SetFloat("allTimeDistance", allTimeDistance);

        allTimeGames = PlayerPrefs.GetFloat("allTimeGames");
        


        multiplier = (float)Math.Round(allTimeDistance / allTimeGames);
        if(multiplier == 0)
        {
            multiplier = 1f;
        }
        PlayerPrefs.SetFloat("multiplier", multiplier);

        allTimeStars = PlayerPrefs.GetFloat("allTimeStars");
        statStars = PlayerPrefs.GetFloat("statStars");

        allTimeStars += PlayerPrefs.GetFloat("levelStars") * multiplier;
        statStars += PlayerPrefs.GetFloat("levelStars") * multiplier;

        PlayerPrefs.SetFloat("allTimeStars", allTimeStars);
        PlayerPrefs.SetFloat("statStars", statStars);



       



    }



    public void revive()
    {

        allTimeResurrect = PlayerPrefs.GetFloat("allTimeResurrect");
        allTimeResurrect += 1;
        PlayerPrefs.SetFloat("allTimeResurrect", allTimeResurrect);

        if (highGameOverMenuUI.activeSelf == true)
        {
            highGameOverMenuUI.SetActive(false);
        }
        revivalMenuUI.SetActive(false);

        revivalOnce = true;

        totalRevives = PlayerPrefs.GetFloat("totalRevives");
        totalRevives -= 1;
        PlayerPrefs.SetFloat("totalRevives", totalRevives);

        Time.timeScale = 1f;

        life = 1;

        reviveSettings();
    }

    public void noRevival()
    {
        Time.timeScale = 1f;
    }
    public void reviveSettings()
    {
        player.transform.position = new Vector3(0f, player.transform.position.y  + 13f, player.transform.position.z);

        playerMovement.enabled = true;
        player.velocity = new Vector2(4f, 4f);
        player.transform.eulerAngles = Vector3.forward * -40f;
        player.GetComponent<Animator>().Play("player_turnRight");
        FindObjectOfType<playerMovement>().assignMoving();
        player.GetComponent<Collider2D>().enabled = true;
        player.GetComponent<SpriteRenderer>().sprite = choiceSprites[nowPlaying];

        return;
    }


    public void revivalIncrement()
    {

        totalRevives += 1;
        PlayerPrefs.SetFloat("totalRevives", totalRevives);

    }


    public void nearMissCount()
    {

        if (life != 0)
        {
            nearMiss = PlayerPrefs.GetFloat("nearMiss");
            nearMiss = nearMiss + 1;
            PlayerPrefs.SetFloat("nearMiss", nearMiss);

            nearMissText.SetActive(true);
        }
        Invoke("nmInactive", 1f);
    }

    public void nmInactive()
    {
        nearMissText.SetActive(false);
    }

}