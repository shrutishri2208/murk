using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstaclePractise : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "obstaclePractise")
        {
            if (PlayerPrefs.GetInt("isVibrateOff") == 0)
            {
                Handheld.Vibrate();
            }
            FindObjectOfType<audioManager>().Play("playerCollision");

            FindObjectOfType<practiseManager>().deadSettings();

        }
    }
}
