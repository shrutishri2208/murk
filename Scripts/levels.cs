using UnityEngine;

public class levels : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collisionInfo)
    {
        if (collisionInfo.tag == "level1")
        {
            PlayerPrefs.SetFloat("level", 1);
        }
        else if (collisionInfo.tag == "level2")
        {
            PlayerPrefs.SetFloat("level", 2);
        }
        else if (collisionInfo.tag == "level3")
        {
            PlayerPrefs.SetFloat("level", 3);
        }
        else if (collisionInfo.tag == "level4")
        {
            PlayerPrefs.SetFloat("level", 4);
        }
        else if (collisionInfo.tag == "level5")
        {
            PlayerPrefs.SetFloat("level", 5);
        }

    }
}