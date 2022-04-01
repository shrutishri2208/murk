using UnityEngine;
using UnityEngine.SceneManagement;

public class introMenu : MonoBehaviour
{
    public void loadLevel()
    {
        SceneManager.LoadSceneAsync("mainMenu");
    }
}
