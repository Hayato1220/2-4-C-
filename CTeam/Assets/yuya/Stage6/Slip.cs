using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slip : MonoBehaviour
{
    public PhysicMaterial slip;

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
    }
}
