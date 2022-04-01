using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial : MonoBehaviour
{
    public GameObject tapText;
    void Start()
    {
        //if(PlayerPrefs.GetFloat("tutorial") != 1 )
        Invoke("startTutorial", 1.5f);
    }

    public void startTutorial()
    {
        Time.timeScale = 0.1f;
        tapText.SetActive(true);
    }

    public void tapTonext()
    {
        Time.timeScale = 1f;
        tapText.SetActive(false);
        do
        {
            Invoke("startTutorial", 0.5f);
            PlayerPrefs.SetFloat("tutorial", 1f);


        } while (PlayerPrefs.GetFloat("tutorial") != 1);

    }
}
