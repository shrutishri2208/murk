using UnityEngine;

public class star : MonoBehaviour
{
    public gameManager gm;
    private void OnTriggerEnter2D(Collider2D collisionInfo)
    {
        if (collisionInfo.tag == "star")
        {
            gm.starIncrement();
            Destroy(collisionInfo.gameObject);

            FindObjectOfType<audioManager>().Play("star");

        }
    }
}