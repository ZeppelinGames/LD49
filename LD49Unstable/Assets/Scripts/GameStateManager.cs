using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStateManager : MonoBehaviour
{
    public Slider coolingSlider;
    public Slider powerSlider;
    public Slider temperatureSlider;

    public float speedMultiplier = 1;

    private float coolingTarget = 0.5f;
    private float powerTarget = 0.5f;

    // Update is called once per frame
    void Update()
    {
        float coolingDist = Mathf.Abs(coolingSlider.value - coolingTarget) / coolingSlider.maxValue;
        float powerDist = Mathf.Abs(powerSlider.value - powerTarget) / powerSlider.maxValue;

        float roundedDist = Mathf.Round((coolingDist + powerDist) / 0.1f) * 0.1f;

        speedMultiplier = 1 + roundedDist;
    }
}
