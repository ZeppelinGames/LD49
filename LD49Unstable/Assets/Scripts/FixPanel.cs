using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FixPanel : MonoBehaviour
{
    public List<Screw> screws = new List<Screw>();

    private Rigidbody rig;
    [HideInInspector] public bool secured = true;

    private float placedTime = 0;

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
            List<Screw> removeScrews = new List<Screw>();
            foreach (Screw screw in screws)
            {
                if (!screw.screwedIn)
                {
                    removeScrews.Add(screw);
                }
            }
            foreach (Screw removeScrew in removeScrews)
            {
                screws.Remove(removeScrew);
            }

            if (screws.Count == 0)
            {
                if (Time.time - placedTime >= 3)
                {
                    BreakPanel();
                }
            }
            else
            {
                ResetPanel(this.transform.parent);
            }
        }
    }

    public void PlacedBack()
    {
        placedTime = Time.time;
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
