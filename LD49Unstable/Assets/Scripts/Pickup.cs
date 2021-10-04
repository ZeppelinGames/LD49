using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Pickup : MonoBehaviour
{
    public Slider addingSlider;

    public LayerMask pickLayers;
    public GameObject HeldObject;

    public List<Screw> heldScrews = new List<Screw>();
    public TextMeshProUGUI screwsCount;

    public List<FixPanel> heldPanels = new List<FixPanel>();

    private float fixTime = 0;
    private bool addingScrew = false;

    // Update is called once per frame
    void Update()
    {
        screwsCount.text = heldScrews.Count.ToString();

        GameObject hitObj = null;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 5, pickLayers))
        {
            hitObj = hit.transform.gameObject;
            Debug.Log(hitObj.name);
        }

        if (hitObj != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (hitObj.GetComponent<Screw>())
                {
                    if (!heldScrews.Contains(hitObj.GetComponent<Screw>()))
                    {
                        heldScrews.Add(hitObj.GetComponent<Screw>());
                        hitObj.SetActive(false);
                    }
                }

                if (hitObj.GetComponent<PanelTarget>())
                {
                    if (HeldObject != null)
                    {
                        if (HeldObject.GetComponent<FixPanel>())
                        {
                            HeldObject.SetActive(true);
                            hitObj.GetComponent<PanelTarget>().SetPanel(HeldObject.GetComponent<FixPanel>());
                            HeldObject = null;
                        }
                    }
                    else
                    {
                        addingScrew = true;
                        fixTime = Time.time;
                    }
                }

                if (HeldObject == null)
                {
                    if (hitObj.GetComponent<FixPanel>())
                    {
                        HeldObject = hitObj;
                        hitObj.SetActive(false);
                    }
                }
            }
        }

        if (addingScrew)
        {
            addingSlider.value = Time.time - fixTime;

            if (hitObj != null)
            {
                if (Time.time - fixTime >= 1)
                {
                    addingScrew = false;
                    if (heldScrews.Count > 0)
                    {
                        if (hitObj.GetComponent<PanelTarget>())
                        {
                            PanelTarget pt = hitObj.GetComponent<PanelTarget>();
                            if (pt.panel != null && pt.panel.screws.Count < 4)
                            {
                                heldScrews[0].ResetScrew();
                                hitObj.GetComponent<PanelTarget>().panel.screws.Add(heldScrews[0]);
                                heldScrews.RemoveAt(0);
                            }
                        }
                    }
                }
            }
        }


        if (Input.GetMouseButtonUp(0) || !addingScrew)
        {
            addingScrew = false;
            addingSlider.value = 0;
        }
    }
}
