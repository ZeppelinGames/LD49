using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FixPanel : MonoBehaviour
{
    public Screw[] screws;

    private Rigidbody rig;
    private bool secured = true;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        rig.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (secured)
        {
            bool allUnscrewed = true;
            foreach (Screw screw in screws)
            {
                if (screw.screwedIn) { allUnscrewed = false; }
            }

            if (allUnscrewed)
            {
                BreakPanel();
            }
        }
    }

    void BreakPanel()
    {
        secured = false;
        rig.isKinematic = false;
        rig.AddForce(transform.right * Random.Range(10, 15) + Vector3.up);
    }
}
