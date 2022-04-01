using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOptions : MonoBehaviour
{

    
    public void restart()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void pause()
    {
        Time.timeScale = 0f;

        FindObjectOfType<audioManager>().Play("menuTransition");

    }


   
    public void pauseWait()
    {
        Time.timeScale = 0f;
    }

}