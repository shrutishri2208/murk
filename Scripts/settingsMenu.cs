using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class settingsMenu : MonoBehaviour
{


    public Image vibrateImage;
    public Image soundImage;
    public Image musicImage;

    public Sprite[] vibrateSprites;
    public Sprite[] soundSprites;
    public Sprite[] musicSprites;

    public TextMeshProUGUI musicOnOff;
    public TextMeshProUGUI soundOnOff;
    public TextMeshProUGUI vibrateOnOff;


    bool isOpen = false;

    public GameObject optionsMenu;

    public audioManager am;
    public audioManager2 am2;



    private void Start()
    {
        if (PlayerPrefs.GetInt("isVibrateOff") == 0)
        {
            vibrateImage.GetComponent<Image>().sprite = vibrateSprites[0];
            vibrateOnOff.text = "ON";
        }
        else
        {
            vibrateImage.GetComponent<Image>().sprite = vibrateSprites[1];
            vibrateOnOff.text = "OFF";

        }



        if (PlayerPrefs.GetInt("isSoundOff") == 0)
        {
            soundImage.GetComponent<Image>().sprite = soundSprites[0];
            soundOnOff.text = "ON";

        }
        else
        {
            soundImage.GetComponent<Image>().sprite = soundSprites[1];
            soundOnOff.text = "OFF";
        }



        if (PlayerPrefs.GetInt("isMusicOff") == 0)
        {
            musicImage.GetComponent<Image>().sprite = musicSprites[0];
            musicOnOff.text = "ON";

        }
        else
        {
            musicImage.GetComponent<Image>().sprite = musicSprites[1];
            musicOnOff.text = "OFF";

        }

    }
   

    public void sound()
    {
        am.Play("click");

        if (PlayerPrefs.GetInt("isSoundOff") == 0)
        {
            PlayerPrefs.SetInt("isSoundOff", 1);
            soundImage.GetComponent<Image>().sprite = soundSprites[1];
            am.soundOff();
            soundOnOff.text = "OFF";

        }
        else
        {
            PlayerPrefs.SetInt("isSoundOff", 0);
            soundImage.GetComponent<Image>().sprite = soundSprites[0];
            am.soundOn();
            soundOnOff.text = "ON";

        }
    }


    public void music()
    {
        am.Play("click");

        if (PlayerPrefs.GetInt("isMusicOff") == 0)
        {
            PlayerPrefs.SetInt("isMusicOff", 1);
            musicImage.GetComponent<Image>().sprite = musicSprites[1];
            am2.musicOff();
            musicOnOff.text = "OFF";


        }
        else
        {
            PlayerPrefs.SetInt("isMusicOff", 0);
            musicImage.GetComponent<Image>().sprite = musicSprites[0];
            am2.musicOn();
            musicOnOff.text = "ON";

        }
    }

    public void vibrate()
    {
        am.Play("click");

        if (PlayerPrefs.GetInt("isVibrateOff") == 0)
        {
            PlayerPrefs.SetInt("isVibrateOff", 1);
            vibrateImage.GetComponent<Image>().sprite = vibrateSprites[1];
            vibrateOnOff.text = "OFF";

        }
        else
        {
            PlayerPrefs.SetInt("isVibrateOff", 0);
            vibrateImage.GetComponent<Image>().sprite = vibrateSprites[0];
            vibrateOnOff.text = "ON";

        }
    }


    
    public void openCloseMenu()
    {
        FindObjectOfType<audioManager>().Play("menuTransition");

        if (isOpen == true)
        {
            //openToClose
            optionsMenu.GetComponent<Animator>().Play("optionsMenuClose");
            isOpen = false;

        }
        else if (isOpen == false)
        {
            //closeToOpen
            optionsMenu.GetComponent<Animator>().Play("optionsMenuOpen");
            isOpen = true;

        }
    }
}