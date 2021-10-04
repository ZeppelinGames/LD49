using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FixPanel : MonoBehaviour
{
    public List<Screw> screws = new List<Screw>();

    private Rigidbody rig;
    private bool secured = true;

    [HideInInspector] private bool heldInPlace = false;

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
                if (!heldInPlace)
                {
                    BreakPanel();
                }
            }
        }
    }

    void BreakPanel()
    {
        secured = false;
        rig.isKinematic = false;
        rig.AddForce(transform.right * Random.Range(10, 15) + Vector3.up);

        CameraShake.instance.AddShakeTime(0.5f);
    }

    public void ResetPanel(Transform setTransform)
    {
        secured = true;
        rig.isKinematic = true;
        transform.position = Vector3.zero;
        transform.rotation = setTransform.rotation;
    }
}
