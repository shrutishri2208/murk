using UnityEngine;

public class obstacle : MonoBehaviour
{
    float enemyHit;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "obstacle")
        {
            enemyHit = PlayerPrefs.GetFloat("enemyHit");
            enemyHit++;
            PlayerPrefs.SetFloat("enemyHit", enemyHit);

            if (PlayerPrefs.GetInt("isVibrateOff") == 0)
            {
                Handheld.Vibrate();
            }
            FindObjectOfType<gameManager>().lifeDecrement();


            FindObjectOfType<audioManager>().Play("playerCollision");
        }
    }
}