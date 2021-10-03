using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTransform : MonoBehaviour
{
    public Vector3 position;
    public Vector3 rotation;

    public float speed = 1;

    // Update is called once per frame
    void Update()
    {
        transform.position += position * Time.deltaTime * speed;
        transform.rotation *= Quaternion.Euler(rotation * Time.deltaTime * speed);
    }
}
