using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleSpawn : MonoBehaviour
{

    private Rigidbody2D obstacle;
    Camera mainCamera;
    void Start()
    {
        obstacle = this.GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
    }

    void Update()
    {

        if (transform.position.y < mainCamera.transform.position.y - 8)
        {
            Destroy(this.gameObject);
        }
    }
}
