using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backColour : MonoBehaviour
{


    public Sprite[] backColorOptions;

    public GameObject backColor;
    void Start()
    {
        int index = Random.Range(0, 5);


        backColor.GetComponent<SpriteRenderer>().sprite = backColorOptions[index];
    }

}