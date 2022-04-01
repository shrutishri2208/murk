using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class mystery : MonoBehaviour
{
    int count;
    int rewardNo;
    float suitX;

    public TextMeshProUGUI mysteryText;
    public TextMeshProUGUI tapTo;
    public TextMeshProUGUI collectText;

    public Image mysteryIcon;

    public Sprite[] mysteryIcons;

    string[] suitNames = new string[4] { 
        "CAPTAIN",
        "CATCHER",
        "CHAMPION",
        "GLITCH",
    };
    public void mysteryMenu()
    {
        FindObjectOfType<audioManager>().Play("treasureOpen");


        count = Random.Range(5, 11);
        rewardNo = Random.Range(8, 12);


        mysteryText.text = " x " + count.ToString("0");
        mysteryIcon.GetComponent<Image>().sprite = mysteryIcons[rewardNo - 8];

        tapTo.text = "TAP TO CONTINUE";

        suitX = PlayerPrefs.GetFloat("suit" + rewardNo);
        suitX += count;
        PlayerPrefs.SetFloat("suit" + rewardNo, suitX);

        collectText.text = "COLLECT  " + (50 - PlayerPrefs.GetFloat("suit" + rewardNo)) + "  MORE TO UNLOCK " + suitNames[rewardNo - 8];


    }
}
