using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{

    Camera mainCamera;
    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {

        if (transform.position.y < mainCamera.transform.position.y - 15f)
        {
            Destroy(this.gameObject);
        }
    }
}
