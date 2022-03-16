using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class subesube : MonoBehaviour
{
    private Rigidbody rb;
    private BoxCollider collider;
    public PhysicMaterial slip;
    public PhysicMaterial nonslip;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<BoxCollider>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Object")
        {
            collider.material = slip;
        }
    }
}
