using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floor : MonoBehaviour
{
    bool GetApush;
    private BoxCollider collider;
    public PhysicMaterial slip;

    void Start()
    {
        collider = GetComponent<BoxCollider>();
    }

    void Update()
    {
        GetApush = touch.Apushflag();
        if(GetApush == true)
        {
            collider.material = slip;
        }
    }
}
