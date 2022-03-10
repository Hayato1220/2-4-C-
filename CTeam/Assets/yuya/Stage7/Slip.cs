using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slip : MonoBehaviour
{
    public PhysicMaterial slip;
    public PhysicMaterial nonslip;

    private BoxCollider CubeCollider;

    void Start()
    {
        CubeCollider = GetComponent<BoxCollider>();
    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetButton("B"))
            {
                CubeCollider.material = slip;
            }
        }

        if (other.gameObject.tag == "Blue" || other.gameObject.tag == "Green" || other.gameObject.tag == "Red" || other.gameObject.tag == "Orange")
        {
            CubeCollider.material = nonslip;
        }
    }
}
