﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touch : MonoBehaviour
{
    public GameObject box;
    public GameObject floor;

    private Rigidbody rb;
    private BoxCollider boxcollider;
    private BoxCollider floorcollider;

    public PhysicMaterial slip;

    static private bool Apush = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        floorcollider = floor.GetComponent<BoxCollider>();
        boxcollider = box.GetComponent<BoxCollider>();
    }

    void OnCollisionStay(Collision collision)
    {
        if (Input.GetButton("A"))
        {
            floorcollider.material = slip;
            boxcollider.material = slip;
            Apush = true;
        }
    }

    static public bool Apushflag()
    {
        return Apush;
    }
}
