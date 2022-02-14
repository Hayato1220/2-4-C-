using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class push : MonoBehaviour
{
    private Rigidbody rb;
    public int force;
    private BoxCollider collider;

    public PhysicMaterial slip;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<BoxCollider>();
        force = 5;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Floor")
        {
            collider.material = slip;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.AddForce(0, 0, force, ForceMode.Impulse);
        }
    }
}
