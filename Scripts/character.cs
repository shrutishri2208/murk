using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class character : MonoBehaviour
{


    public GameObject suitImage;




    public TextMeshProUGUI suitStatusAndCostDisplay;
    public TextMeshProUGUI suitName;

    public Sprite[] suitChoices;
    string[] suitStatusAndCosts = new string[12]
    {
        "SELECT",
        "      100",
        "      500",
        "      1000",
        "      2000",
        "      3000",
        "      4000",
        "      5000",
        "",
        "",
        "",
        "",

    };
    string[] suitNames = new string[12]
    {
        "CURIO",
        "EMERALD",
        "CORAL",
        "BROOK",
        "BLAZE",
        "TRIBER",
        "DIVER",
        "BOWMAN",
        "CAPTAIN",
        "CATCHER",
        "CHAMPION",
        "GLITCH",

    };
    public GameObject[] selectBackWhite;
    public GameObject[] locks;

    public Sprite[] selectIcon;
    public Image selectIconImage;
    public Image selectBack;


    int arrayIndex;


    int selectedIndex;


    public Button buySelectMainButton;


    public TextMeshProUGUI totalStarsText;


    float allTimeStars;
    float allTimeSuits;
    float allTimeBadges;
    float totalRevives;





    //characterSelectionMenuVariables
    public GameObject characterSelectionMenu;
    public TextMeshProUGUI CSsuitName;
    public GameObject CSsuitImage;
    public GameObject CSsuitImageWhite;
    public Sprite[] CSsuitImageWhites;




    void Start()
    {

        suitImage.GetComponent<Image>().sprite = suitChoices[PlayerPrefs.GetInt("lastBought")];
        selectBackWhite[PlayerPrefs.GetInt("lastBought")].SetActive(true);

        characterUpdate();
    }



    public void characterUpdate()
    {

        allTimeStars = PlayerPrefs.GetFloat("allTimeStars");
        allTimeBadges = PlayerPrefs.GetFloat("allTimeBadges");
        totalRevives = PlayerPrefs.GetFloat("totalRevives");

        totalStarsText.text = allTimeStars.ToString();

        PlayerPrefs.SetInt("suitStatus0", 1);

        for (int i = 0; i < 12; i++)
        {
            if (PlayerPrefs.GetInt("suitStatus" + i) == 1)
            {
                locks[i].SetActive(false);
            }
        }

        for (int b = 0; b <= 11; b++)
        {
            if (PlayerPrefs.GetInt("suitStatus" + b) == 1)
            {
                suitStatusAndCosts[b] = "SELECT";
            }
        }


    }


    public void suitChoice(int a)
    {
        FindObjectOfType<audioManager>().Play("click");

        arrayIndex = a;

        PlayerPrefs.SetInt("arrayIndex", arrayIndex);




        for (int i = 0; i < 12; i++)
        {
            selectBackWhite[i].SetActive(false);
            selectBackWhite[a].SetActive(true);

        }


        suitImage.GetComponent<Image>().sprite = suitChoices[arrayIndex];
        suitName.text = suitNames[arrayIndex];


        suitStatusAndCostDisplay.text = suitStatusAndCosts[arrayIndex];

        if (arrayIndex >= 0 && arrayIndex <= 7)
        {

            selectIconImage.GetComponent<Image>().sprite = selectIcon[0];
            suitStatusAndCostDisplay.transform.localPosition = new Vector2(0f, 0f);


            if (PlayerPrefs.GetInt("suitStatus" + arrayIndex) == 1)
            {
                //bought
                buySelectMainButton.GetComponent<Button>().interactable = true;
                selectIconImage.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
                selectBack.GetComponent<Image>().color = new Color(0.2169f, 0.2169f, 0.2169f, 1f);

            }
            else if (int.Parse(suitStatusAndCosts[arrayIndex]) <= allTimeStars)
            {
                //canBuy
                buySelectMainButton.GetComponent<Button>().interactable = true;
                selectBack.GetComponent<Image>().color = new Color(0.2169f, 0.2169f, 0.2169f, 1f);

                selectIconImage.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);

            }
            else
            {
                //cannotBuy
                buySelectMainButton.GetComponent<Button>().interactable = false;
                selectBack.GetComponent<Image>().color = new Color(0.2169f, 0.2169f, 0.2169f, 0.5f);

                selectIconImage.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
            }
        }
        else if (arrayIndex >= 8 && arrayIndex <= 11)
        {

            
            if (PlayerPrefs.GetInt("suitStatus" + arrayIndex) == 1)
            {
                //bought
                buySelectMainButton.GetComponent<Button>().interactable = true;
                selectBack.GetComponent<Image>().color = new Color(0.2169f, 0.2169f, 0.2169f, 1f);
                selectIconImage.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);

                suitStatusAndCostDisplay.transform.localPosition = new Vector2(0f, 0f);


            }
            else if (PlayerPrefs.GetFloat("suit" + arrayIndex) >= 50f)
            {
                //canBuy
                buySelectMainButton.GetComponent<Button>().interactable = true;
                selectBack.GetComponent<Image>().color = new Color(0.2169f, 0.2169f, 0.2169f, 1f);
                selectIconImage.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);

                suitStatusAndCostDisplay.transform.localPosition = new Vector2(40f, 0f);

                suitStatusAndCostDisplay.text = PlayerPrefs.GetFloat("suit" + arrayIndex).ToString("0") + "/50";
                selectIconImage.GetComponent<Image>().sprite = selectIcon[arrayIndex - 7];

            }
            else
            {
                //cannotBuy
                buySelectMainButton.GetComponent<Button>().interactable = false;
                selectBack.GetComponent<Image>().color = new Color(0.2169f, 0.2169f, 0.2169f, 0.5f);
                selectIconImage.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);

                suitStatusAndCostDisplay.transform.localPosition = new Vector2(40f, 0f);

                suitStatusAndCostDisplay.text = PlayerPrefs.GetFloat("suit" + arrayIndex).ToString("0") + "/50";
                selectIconImage.GetComponent<Image>().sprite = selectIcon[arrayIndex - 7];

            }
        }
        
    }

    public void nowPlaying()
    {
        selectedIndex = PlayerPrefs.GetInt("arrayIndex");
        int nowPlayingIndex = selectedIndex;
        PlayerPrefs.SetInt("nowPlaying", nowPlayingIndex);
    }

    public void buySelectMain()
    {
        selectedIndex = PlayerPrefs.GetInt("arrayIndex");


        suitStatusAndCostDisplay.transform.localPosition = new Vector2(0f, 0f);

        if (PlayerPrefs.GetInt("suitStatus" + selectedIndex) != 1)
        {
            if(selectedIndex >= 0 && selectedIndex <= 7)
            {
                deductStars();
            }
            PlayerPrefs.SetInt("suitStatus" + selectedIndex, 1);
            allTimeSuits = PlayerPrefs.GetFloat("allTimeSuits");
            allTimeSuits += 1;
            PlayerPrefs.SetFloat("allTimeSuits", allTimeSuits);
            if (allTimeSuits == 2 && PlayerPrefs.GetFloat("status21") != 1)
            {
                //UNLOCK ALL THE SUITS
                PlayerPrefs.SetFloat("status21", 1f);
                allTimeBadges += 1;
                PlayerPrefs.SetFloat("allTimeBadges", allTimeBadges);
                totalRevives += 2;
                PlayerPrefs.SetFloat("totalRevives", totalRevives);

            }


            for (int i = 0; i < 12; i++)
            {
                if (PlayerPrefs.GetInt("suitStatus" + i) == 1)
                {
                    locks[i].SetActive(false);
                }
            }

            for (int b = 0; b <= 11; b++)
            {
                if (PlayerPrefs.GetInt("suitStatus" + b) == 1)
                {
                    suitStatusAndCosts[b] = "SELECT";
                }
            }

            //characterSelectionFunctions
            FindObjectOfType<audioManager>().Play("suitSelection");

            characterSelectionMenu.SetActive(true);
            if (selectedIndex == 9)
            {
                CSsuitImageWhite.GetComponent<Image>().sprite = CSsuitImageWhites[1];
            }
            else
            {
                CSsuitImageWhite.GetComponent<Image>().sprite = CSsuitImageWhites[0];

            }

            CSsuitImage.GetComponent<Image>().sprite = suitChoices[selectedIndex];
            CSsuitName.text = suitNames[selectedIndex];


            //suitImage.SetActive(false);

        }
        else
        {
            for (int b = 0; b <= 11; b++)
            {
                if (PlayerPrefs.GetInt("suitStatus" + b) == 1)
                {
                    suitStatusAndCosts[b] = "SELECT";
                }
            }
            gameObject.GetComponent<Animator>().Play("suitsMenuClose");
            FindObjectOfType<audioManager>().Play("menuTransition");

        }
        PlayerPrefs.SetInt("lastBought", selectedIndex);

        suitStatusAndCosts[selectedIndex] = "SELECT";
        suitStatusAndCostDisplay.text = "SELECTED";
        selectIconImage.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);


    }
    public void deductStars()
    {
        float totalStarsLeft = PlayerPrefs.GetFloat("allTimeStars");
        totalStarsLeft -= int.Parse(suitStatusAndCosts[selectedIndex]);
        PlayerPrefs.SetFloat("allTimeStars", totalStarsLeft);
        totalStarsText.text = totalStarsLeft.ToString();
    }


    public void tapTocontinue()
    {
        this.gameObject.SetActive(false);
        FindObjectOfType<audioManager>().Play("menuTransition");
        //mainSuitImage.SetActive(true);
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("mainMenu");
    }


    public void menuTransitionSound()
    {
        FindObjectOfType<audioManager>().Play("menuTransition");
    }


    void Update()
    {
        suitStatusAndCosts[PlayerPrefs.GetInt("nowPlaying")] = "SELECTED";
    }
}