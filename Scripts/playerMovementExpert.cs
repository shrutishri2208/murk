using TMPro;
using UnityEngine;
using System;

public class playerMovementExpert : MonoBehaviour
{
    public Rigidbody2D player;
    public float acceleration;

    bool movingRight;
    bool buttonDown = false;

    int arrIndex;
    int nowPlaying;
    public TextMeshProUGUI levelDistanceText;



    public Sprite[] choiceSprites;

    public GameObject playerStartImage;
    public GameObject controlCanvas;

    float levelDistance;
    float wallHit;

    public GameObject obstacle;

    public audioManager am;
    void Start()
    {

        Time.timeScale = 1f;
        player = GetComponent<Rigidbody2D>();

        
        PlayerPrefs.SetFloat("level", 1f);

        Invoke("delayControlCanvas", 1.5f);
        Invoke("startMovement", 1.5f);

        arrIndex = PlayerPrefs.GetInt("arrayIndex");

        nowPlaying = PlayerPrefs.GetInt("nowPlaying");
        playerStartImage.GetComponent<SpriteRenderer>().sprite = choiceSprites[nowPlaying];


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
    private void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.collider.tag == "leftWall")
        {
            //toMoveRight
            transform.eulerAngles = Vector3.forward * -40;
            player.velocity = new Vector2(acceleration, acceleration);
            movingRight = true;

            am.Play("wall");

            wallHit = PlayerPrefs.GetFloat("wallHit");
            wallHit = wallHit + 1;
            PlayerPrefs.SetFloat("wallHit", wallHit);
        }
        else if (collisionInfo.collider.tag == "rightWall")
        {
            //toMoveLeft
            transform.eulerAngles = Vector3.forward * 40;
            player.velocity = new Vector2(-acceleration, acceleration);
            movingRight = false;

            am.Play("wall");

            wallHit = PlayerPrefs.GetFloat("wallHit");
            wallHit = wallHit + 1;
            PlayerPrefs.SetFloat("wallHit", wallHit);

        }
    }


    public void assignMoving()
    {
        movingRight = false;
    }

    public void ButtonIsDown()
    {
        buttonDown = true;
    }

    public void ButtonIsUp()
    {
        buttonDown = false;

    }

    public void SwitchDirection()
    {
        movingRight = !movingRight;
        am.Play("playerMovement");
    }

    void Update()
    {

        player.GetComponent<SpriteRenderer>().sprite = choiceSprites[nowPlaying];


        if (buttonDown && movingRight)
        {   //shud move to right
            transform.eulerAngles = Vector3.forward * -40;
            player.velocity = new Vector2(acceleration, acceleration);
        }
        else if (buttonDown)
        {   //shud move to left
            transform.eulerAngles = Vector3.forward * 40;
            player.velocity = new Vector2(-acceleration, acceleration);
        }

        levelDistance = PlayerPrefs.GetFloat("levelDistance");
        levelDistance += (Time.deltaTime / 3f);
        levelDistanceText.GetComponent<TextMeshProUGUI>().text = Math.Round(levelDistance, 1).ToString();
        PlayerPrefs.SetFloat("levelDistance", levelDistance);


    }

}







