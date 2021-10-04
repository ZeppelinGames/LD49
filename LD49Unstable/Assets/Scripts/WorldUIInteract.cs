using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WorldUIInteract : MonoBehaviour { 
    void Update()
    {
        RaycastWorldUI();
    }

    void RaycastWorldUI()
    {
        if (Input.GetMouseButton(0))
        {
            PointerEventData pointerData = new PointerEventData(EventSystem.current);
            pointerData.position = Input.mousePosition;

            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerData, results);
        }
    }
}