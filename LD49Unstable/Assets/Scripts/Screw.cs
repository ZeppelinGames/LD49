using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Screw : MonoBehaviour
{
    public bool screwedIn = true;

    private Rigidbody rig;
    private float unscrewSpeed = 0.1f;
    private float screwLevel = 1;

    private void Start()
    {
        rig = GetComponent<Rigidbody>();
        rig.isKinematic = true;

        screwLevel = Random.Range(0.5f, 1);
        unscrewSpeed = Random.Range(0.05f, 0.15f);
    }

    void Update() {
        if(screwedIn) {
            screwLevel -= Random.Range(-0.5f,1f) * unscrewSpeed * Time.deltaTime;
            screwLevel = Mathf.Clamp01(screwLevel);

            if (screwLevel <= 0.1f)
            {
                Unscrew();
            }
        }
    }

    void Unscrew() {
        screwedIn = false;
        rig.isKinematic = false;
        rig.AddForce(transform.right * Random.Range(3,10) + Vector3.up);
    }
}
