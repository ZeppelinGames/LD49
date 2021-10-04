using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameStateManager : MonoBehaviour
{
    public UnityEvent reactorBlowUp;
    [HideInInspector] public bool dead = false;

    public Slider coolingSlider;
    public Slider powerSlider;
    public Slider temperatureSlider;

    public Slider coolingTargetSlider;
    public Slider powerTargetSlider;

    public FixPanel[] allPanels;

    public float speedMultiplier = 1;

    private float coolingTarget = 1;
    private float powerTarget = 1;

    private float coolingOffset = 0.5f;
    private float powerOffset = 0.2f;

    private int temperatureTarget = 1;
    private float tempValue = 1;

    [HideInInspector] public bool canBlowup = true;

    private void Start()
    {
        coolingTarget = Random.Range(1, 10);
        powerTarget = Random.Range(1, 10);

        coolingOffset = Random.Range(-10f, 10f);
        powerOffset = Random.Range(-10f, 10f);
    }


    // Update is called once per frame
    void Update()
    {
        coolingTargetSlider.value = coolingTarget;
        powerTargetSlider.value = powerTarget;

        coolingTarget = (Mathf.Sin((Time.time + coolingOffset) / Random.Range(90, 100)) * 5 + 5);
        powerTarget = (Mathf.Sin((Time.time + powerOffset) / Random.Range(90, 100)) * 5 + 5);

        coolingTarget = Mathf.Clamp(coolingTarget, 1, coolingSlider.maxValue);
        powerTarget = Mathf.Clamp(powerTarget, 1, powerSlider.maxValue);

        float coolingDist = Mathf.Abs(coolingSlider.value - coolingTarget) / coolingSlider.maxValue;
        float powerDist = Mathf.Abs(powerSlider.value - powerTarget) / powerSlider.maxValue;

        float roundedDist = Mathf.Round((coolingDist + powerDist) / 0.1f) * 0.1f;

        speedMultiplier = 1 + roundedDist;

        int offPanelCount = 0;
        foreach (FixPanel panel in allPanels)
        {
            if (!panel.secured)
            {
                offPanelCount++;
            }
        }

        temperatureTarget = Mathf.RoundToInt((coolingDist * 5) + (powerDist * 5) + (offPanelCount * 3));

        tempValue = Mathf.MoveTowards(tempValue, temperatureTarget, Time.deltaTime);
        tempValue = Mathf.Clamp(tempValue, 1, temperatureSlider.maxValue);
        temperatureSlider.value = Mathf.RoundToInt(tempValue);

        if (canBlowup)
        {
            if (temperatureSlider.value >= temperatureSlider.maxValue)
            {
                Debug.Log("Ya dead");
                //BLOW UP
                dead = true;
                reactorBlowUp.Invoke();
            }
        }
        else
        {
            temperatureTarget = 1;
        }
    }
}
