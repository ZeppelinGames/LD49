using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Pickup : MonoBehaviour
{
    public LayerMask pickLayers;
    public GameObject HeldObject;

    public List<Screw> heldScrews = new List<Screw>();
    public TextMeshProUGUI screwsCount;

    public List<FixPanel> heldPanels = new List<FixPanel>();

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
            if (hitObj.GetComponent<FixPanel>())
            {
                if (!heldPanels.Contains(hitObj.GetComponent<FixPanel>()))
                {
                    heldPanels.Add(hitObj.GetComponent<FixPanel>());
                }
            }

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

                if (hitObj.GetComponent<FixPanel>())
                {
                    if (HeldObject == null)
                    {

                        HeldObject = hitObj;
                        HeldObject.SetActive(false);
                    }
                    else
                    {
                        HeldObject.transform.position = transform.position + (transform.forward * 2);
                        HeldObject.GetComponent<Rigidbody>().isKinematic = false;
                        HeldObject.SetActive(true);

                        HeldObject = hitObj;
                        HeldObject.SetActive(false);
                    }
                }

                if (HeldObject != null)
                {
                    if (hitObj.CompareTag("PanelTarget"))
                    {

                        if (HeldObject.GetComponent<FixPanel>())
                        {
                            HeldObject.SetActive(true);
                            HeldObject.GetComponent<FixPanel>().ResetPanel(hitObj.transform);
                            HeldObject = null;
                        }
                    }
                }
            }
        }
    }
}
