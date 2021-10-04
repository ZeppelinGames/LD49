using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoScale : MonoBehaviour
{
    public Vector3 scaleDims = Vector3.one;
    public float scaleSpeed = 1;
    public bool autoStart = false;
    public bool start = false;

    // Update is called once per frame
    void Update()
    {
        if (start || autoStart)
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, transform.localScale + Vector3.one, Time.deltaTime * scaleSpeed);
        }
    }

    public void Activate()
    {
        start = true;
    }
}
