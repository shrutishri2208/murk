using UnityEngine;

public class leftAndRight : MonoBehaviour
{
    float delta = 1.5f;  // Amount to move left and right from the start point
    float speed;
    private Vector3 startPos;


    void Start()
    {
        startPos = transform.position;
        speed = Random.Range(-1.5f, 1.5f);
    }


    void Update()
    {
        Vector3 v = startPos;
        v.x += delta * Mathf.Sin(Time.time * speed);
        transform.position = v;
    }
}