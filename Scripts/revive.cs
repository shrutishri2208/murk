using UnityEngine;

public class revive : MonoBehaviour
{
    float statRevives;
    private void OnTriggerEnter2D(Collider2D collisionInfo)
    {
        if (collisionInfo.tag == "revive")
        {
            FindObjectOfType<gameManager>().revivalIncrement();
            Destroy(collisionInfo.gameObject);
            statRevives = PlayerPrefs.GetFloat("statRevives");
            statRevives += 1;
            PlayerPrefs.SetFloat("statRevives", statRevives);

            FindObjectOfType<audioManager>().Play("life");

        }
    }
}