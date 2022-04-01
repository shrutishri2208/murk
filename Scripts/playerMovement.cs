using TMPro;
using UnityEngine;
using System;

public class playerMovement : MonoBehaviour
{
    public Rigidbody2D player;
    public float acceleration;

    bool movingRight;
    bool buttonDown = false;

    int arrIndex;
    //int nowPlaying;
    public TextMeshProUGUI levelDistanceText;


    //public Sprite[] choiceSprites;

    public GameObject playerStartImage;
    public GameObject controlCanvas;

    float levelDistance;

    public GameObject obstacle;

    public audioManager am;
    void Start()
    {

        Time.timeScale = 1f;
        player = GetComponent<Rigidbody2D>();
        
        PlayerPrefs.SetFloat("level", 1f);

        Invoke("delayControlCanvas", 2f);
        Invoke("startMovement", 2f);

        arrIndex = PlayerPrefs.GetInt("arrayIndex");

        //nowPlaying = PlayerPrefs.GetInt("nowPlaying");
        //playerStartImage.GetComponent<SpriteRenderer>().sprite = choiceSprites[nowPlaying];


        obstacle.GetComponent<CircleCollider2D>().radius = 1.7f;


    }


    public void delayControlCanvas()
    {
        controlCanvas.SetActive(true);
    }


    public void startMovement()
    {
        playerStartImage.SetActive(false);
        player.GetComponent<SpriteRenderer>().enabled = true;
        transform.eulerAngles = Vector3.forward * -40f;
        player.velocity = new Vector2(acceleration, acceleration);
        movingRight = false;
    }

    public void moveLeft()
    {
        //transform.eulerAngles = Vector3.forward * 40f;
        player.GetComponent<Animator>().Play("player_turnLeft");
        player.velocity = new Vector2(-acceleration, acceleration);
        movingRight = false;


        am.Play("wall");
        if (FindObjectOfType<gameManager>() != null)
        {
            FindObjectOfType<gameManager>().wallIncrement();

        }


    }

    public void moveRight()
    {
        //transform.eulerAngles = Vector3.forward * -40f;
        player.GetComponent<Animator>().Play("player_turnRight");
        player.velocity = new Vector2(acceleration, acceleration);
        movingRight = true;

        am.Play("wall");

        if (FindObjectOfType<gameManager>() != null)
        {
            FindObjectOfType<gameManager>().wallIncrement();

        }


    }



    public void assignMoving()
    {
        movingRight = false;
    }

    public void ButtonIsDown()
    {
        /*if(Time.timeScale != 1)
        {
            Time.timeScale = 1;
        }*/
        buttonDown = true;
        Debug.Log(buttonDown);
    }

    public void ButtonIsUp()
    {
        buttonDown = false;
        Debug.Log(buttonDown);

    }

    public void SwitchDirection()
    {
        movingRight = !movingRight;
        am.Play("playerMovement");
    }

    void Update()
    {

        if (buttonDown && movingRight)
        {   //shud move to right
            //transform.eulerAngles = Vector3.forward * -40f;
            player.GetComponent<Animator>().Play("player_turnRight");
            player.velocity = new Vector2(acceleration, acceleration);
        }
        else if(buttonDown)
        {   //shud move to left
            //transform.eulerAngles = Vector3.forward * 40f;
            player.GetComponent<Animator>().Play("player_turnLeft");
            player.velocity = new Vector2(-acceleration, acceleration);
        }

        levelDistance = PlayerPrefs.GetFloat("levelDistance");
        levelDistance += (Time.deltaTime / 3f);
        levelDistanceText.text = Math.Round(levelDistance, 1).ToString() + "m";
        PlayerPrefs.SetFloat("levelDistance", levelDistance);


    }

}







