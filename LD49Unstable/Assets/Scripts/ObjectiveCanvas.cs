using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class ObjectiveCanvas : MonoBehaviour
{
    public GameStateManager gameState;
    public UnityEvent gameWinEvents;

    public TextMeshProUGUI currObjText;
    public TextMeshProUGUI mainObjText;
    public TextMeshProUGUI subObj1Text;
    public TextMeshProUGUI subObj2Text;

    private string baseCurrObjText = "CURRENT OBJECTIVE";
    public float timeRemaining = 300;

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining <= 0)
        {
            if (!gameState.dead)
            {
                gameState.canBlowup = false;
                Debug.Log("You didnt die");

                SetObjectives(baseCurrObjText,
                    "GO HOME",
                    "PLEASE DON'T GO NEAR A NUCLEAR REACTOR AGAIN",
                    "WHERE DID YOU EVEN GET YOUR LICENSE FROM");

                gameWinEvents.Invoke();
            }
        }

        currObjText.text = baseCurrObjText + " " + GetTimeString();
        timeRemaining -= Time.deltaTime;
    }

    public string GetTimeString()
    {
        if (timeRemaining < 0) { timeRemaining = 0; }

        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);

        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void SetObjectives(string currObj, string mainObj, string sub1Obj, string sub2Obj)
    {
        baseCurrObjText = currObj;
        mainObjText.text = mainObj;
        subObj1Text.text = sub1Obj;
        subObj2Text.text = sub2Obj;
    }

    public void SetMainObj(string mainObj)
    {
        mainObjText.text = mainObj;
    }

    public void SetTimeRemaining(float timeRem)
    {
        timeRemaining = timeRem;
    }
}
