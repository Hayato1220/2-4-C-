using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;

public class Slice : MonoBehaviour
{
    public GameObject Cube;

    private void Start()
    {
        Cube.SliceInstantiate
            (
                position: Vector3.zero,
                direction: new Vector3(1, 1, 1)
            ); ;
    }

}
