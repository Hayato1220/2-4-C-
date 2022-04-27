using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    void Start()
    {
        var lineRenderer = gameObject.AddComponent<LineRenderer>();

        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;

        var positions = new Vector3[]
        {
        new Vector3(10,20,0),
        new Vector3(15,15,0),
        new Vector3(10,10,0),
        };

        lineRenderer.positionCount = positions.Length;

        lineRenderer.SetPositions(positions);
    }
}