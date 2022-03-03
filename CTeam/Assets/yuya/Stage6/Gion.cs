using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gion : MonoBehaviour
{
    public PhysicMaterial slip;

    public GameObject cube;

    private BoxCollider CubeCollider;

    void Start()
    {
        CubeCollider = cube.GetComponent<BoxCollider>();
    }

    void OnCollisionStay(Collision other)
    {
        if(other.gameObject.tag == "Ball")
        {
            if (Input.GetButton("B"))
            {
                CubeCollider.material = slip;
            }
        }
    }
}
