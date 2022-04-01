using UnityEngine;
using UnityEngine.UI;
using System;

public class headerMenu : MonoBehaviour
{
    bool isOpen = false;

    public GameObject headerMenuUI;
    public Image upDownArrow;

    public Sprite[] upDown;


    public void openCloseMenu()
    {
        if(isOpen == true)
        {
            //openToClose
            headerMenuUI.GetComponent<Animator>().Play("headerMenuClose");
            isOpen = false;
            upDownArrow.GetComponent<Image>().sprite = upDown[0];

        }
        else if(isOpen == false)
        {
            //closeToOpen
            headerMenuUI.GetComponent<Animator>().Play("headerMenuOpen");
            isOpen = true;
            upDownArrow.GetComponent<Image>().sprite = upDown[1];

        }
    }


    public void linkedin()
    {
        Debug.Log("Linkedin");
        Application.OpenURL("https://www.linkedin.com/in/shruti-shrivastava-676606228/");
    }

    /*public void email()
    {
        string email = "murk.unity@gmail.com";
        string subject = MyEscapeURL("My Subject");
        string body = MyEscapeURL("My Body\r\nFull of non-escaped chars");
        Application.OpenURL("mailto:" + email + "?subject=" + subject + "&body=" + body);
    }
    string MyEscapeURL(string url)
    {
        return WWW.EscapeURL(url).Replace("+", "%20");
    }*/
    public void email()
    {
        Application.OpenURL("mailto:murk.unity@gmail.com?subject=Feedback/Suggestion");
    }

    public void site()
    {
        Application.OpenURL("https://www.shrutz.xyz");
    }
}
