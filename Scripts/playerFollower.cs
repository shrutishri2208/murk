using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFollower : MonoBehaviour
{
    Transform player;

    float offsetY;

    public float posOffset;

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

        if (playerObj == null)
        {
            Debug.LogError("Could not find an object with tag 'Player'");
        }

        player = playerObj.transform;

        offsetY = transform.position.y - player.position.y;
    }

    void Update()
    {
        if (player.position.y > 0)
        {
            Vector3 pos = transform.position;
            pos.y = player.position.y - (offsetY / 2) + posOffset;
            transform.position = pos;
        }
    }
}