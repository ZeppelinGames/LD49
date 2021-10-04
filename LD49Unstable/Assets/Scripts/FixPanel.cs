using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FixPanel : MonoBehaviour
{
    public List<Screw> screws = new List<Screw>();

    public Transform[] screwPositions;

    private Rigidbody rig;
    [HideInInspector] public bool secured = true;

    private float placedTime = 0;

    public ScrewHole[] screwHoles = new ScrewHole[4];

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        rig.isKinematic = true;

        for (int i = 0; i < screwPositions.Length; i++)
        {
            screwHoles[i] = new ScrewHole(screwPositions[i], screws[i]);
            if (screws[i] != null)
            {
                screws[i].transform.position = screwPositions[i].position;
                screws[i].transform.rotation = screwPositions[i].rotation;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < screws.Count; i++)
        {
            bool hasScrew = false;
            for (int j = 0; j < screwHoles.Length; j++)
            {
                if (screwHoles[j].screw == screws[i])
                {
                    hasScrew = true;
                }
            }


            if (!hasScrew)
            {
                bool foundPos = false;
                for (int j = 0; j < screwHoles.Length; j++)
                {
                    if (!foundPos)
                    {
                        if (screwHoles[j].screw == null)
                        {
                            screwHoles[j].screw = screws[i];
                            screws[i].rig.position = screwHoles[j].hole.position;
                            screws[i].transform.position = screwHoles[j].hole.position;
                            screws[i].transform.rotation = screwHoles[j].hole.rotation;
                            foundPos = true;
                        }
                    }
                }
            }
        }

        if (secured)
        {
            List<Screw> removeScrews = new List<Screw>();
            for (int i = 0; i < screws.Count; i++)
            {
                if (!screws[i].screwedIn)
                {
                    for (int j = 0; j < screwHoles.Length; j++)
                    {
                        if (screwHoles[j].screw == screws[i])
                        {
                            screwHoles[j].screw = null;
                        }
                    }


                    removeScrews.Add(screws[i]);
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

[System.Serializable]
public class ScrewHole
{
    public Transform hole;
    public Screw screw;

    public ScrewHole(Transform hole, Screw screw)
    {
        this.hole = hole;
        this.screw = screw;
    }
}