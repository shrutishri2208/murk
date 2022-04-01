using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerStart : MonoBehaviour
{

    public Sprite[] choiceSprites;
    int nowPlaying;

    void Start()
    {
        nowPlaying = PlayerPrefs.GetInt("nowPlaying");
        gameObject.GetComponent<SpriteRenderer>().sprite = choiceSprites[nowPlaying];

    }
}
