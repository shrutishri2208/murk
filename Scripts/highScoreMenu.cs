using UnityEngine;

public class highScoreMenu : MonoBehaviour
{
    float highScoreNo;
    public void Start()
    {

        highScoreNo = PlayerPrefs.GetFloat("highScoreNo");
        highScoreNo += 1;
        PlayerPrefs.SetFloat("highScoreNo", highScoreNo);
    }


  
} 