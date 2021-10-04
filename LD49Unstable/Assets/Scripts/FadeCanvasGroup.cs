using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeCanvasGroup : MonoBehaviour
{
    public float fadeToAlpha;
    public float fadeSpeed = 3;
    private CanvasGroup img;

    private bool start = false;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            img.alpha = Mathf.Lerp(img.alpha, fadeToAlpha, Time.deltaTime * fadeSpeed);
        }
    }

    public void FadeIn()
    {
        start = true;
    }
}
