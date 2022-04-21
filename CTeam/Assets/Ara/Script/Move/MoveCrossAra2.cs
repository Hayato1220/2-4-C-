﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCrossAra2 : MonoBehaviour
{
    Vector3 targetpos;

    public bool getCross;

    [SerializeField]
    Vector3 Rote;

    [SerializeField]
    public float Speed = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        targetpos = transform.position;

        getCross = false;
    }

    void Update()
    {

        getCross = GetCrossAra.CrossGet();

        if (getCross == true)
        {
            if (targetpos.x <= 13.2f)
            {
                targetpos.x += Speed;
                transform.position = new Vector3(targetpos.x, targetpos.y, targetpos.z);
            }

            if (targetpos.x >= 13.1f)
            {
                transform.Rotate(Rote);
            }
        }
    }
}
