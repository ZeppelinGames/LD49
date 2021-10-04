using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColourFade : MonoBehaviour
{
    public Color fadeToColour;
    public float fadeSpeed = 3;
    private Image img;

    private bool start = false;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            img.color = Color.Lerp(img.color, fadeToColour, Time.deltaTime * fadeSpeed);
        }
    }

    public void GoBlind()
    {
        start = true;
    }
}
