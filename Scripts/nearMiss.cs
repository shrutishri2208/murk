using UnityEngine;

public class nearMiss : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collisionInfo)
    {
        if (collisionInfo.tag == "nearMiss")
        {
            FindObjectOfType<gameManager>().nearMissCount();
        }
    }
}