using TMPro;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;


public class practiseManager : MonoBehaviour
{
    public Rigidbody2D player;

    public Sprite suit0;
    public Sprite deadSprite;
    playerMovement playerMovement;


    Vector2 fall;

    public GameObject continuePanel;

    float practiceLevelDistance;
    public TextMeshProUGUI practiceLevelDistanceText;


    void Start()
    {
        playerMovement = FindObjectOfType<playerMovement>();
        fall = new Vector2(0f, -60f);
        player.GetComponent<SpriteRenderer>().sprite = suit0;
    }



    public void deadSettings()
    {
        Invoke("delayCP", 1f);
        playerMovement.enabled = false;
        player.GetComponent<SpriteRenderer>().sprite = deadSprite;
        player.GetComponent<Animator>().Play("player_dead");
        player.GetComponent<Collider2D>().enabled = false;
        player.AddForce(fall);
        FindObjectOfType<deployPractiseObjects>().stopCoroutine();
    }

    void delayCP()
    {
        continuePanel.SetActive(true);
    }


    public void revive()
    {
        player.GetComponent<SpriteRenderer>().sprite = suit0;
        continuePanel.SetActive(false);
        player.transform.position = new Vector3(0f, player.transform.position.y + 13f, player.transform.position.z);
        playerMovement.enabled = true;
        player.velocity = new Vector2(4f, 4f);
        player.transform.eulerAngles = Vector3.forward * -40f;
        player.GetComponent<Animator>().Play("player_turnRight");

        FindObjectOfType<playerMovement>().assignMoving();
        player.GetComponent<Collider2D>().enabled = true;
        FindObjectOfType<deployPractiseObjects>().startCoroutine();

        return;

    }

    public void quitGame()
    {
        //Time.timeScale = 1f;
        FindObjectOfType<audioManager>().Play("click");

        SceneManager.LoadSceneAsync("mainMenu");


    }

    private void Update()
    {
        practiceLevelDistance += (Time.deltaTime / 3f);
        practiceLevelDistanceText.text = Math.Round(practiceLevelDistance, 1).ToString() + "m";

    }

}