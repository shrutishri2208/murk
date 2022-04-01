using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
    public float zRotation;
    void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, zRotation) * Time.deltaTime);
    }
}
