using UnityEngine;

public class colliderPlacer : MonoBehaviour
{
    public Camera mainCamera;

    public BoxCollider2D leftWall;
    public BoxCollider2D rightWall;

    void Start()
    {
        leftWall.size = new Vector2(1f, mainCamera.ScreenToWorldPoint(new Vector3(0f, Screen.height * 2, 0f)).y);
        leftWall.offset = new Vector2(mainCamera.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).x - 0.5f, mainCamera.transform.position.y);


        rightWall.size = new Vector2(1f, mainCamera.ScreenToWorldPoint(new Vector3(0f, Screen.height * 2, 0f)).y);
        rightWall.offset = new Vector2(-(mainCamera.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).x - 0.5f), mainCamera.transform.position.y);
    }
}