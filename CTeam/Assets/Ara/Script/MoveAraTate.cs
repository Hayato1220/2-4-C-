using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAraTate : MonoBehaviour
{
    Vector3 targetpos;

    [SerializeField]
    public float Speed = 5f;


    // Start is called before the first frame update
    void Start()
    {
        targetpos = transform.position;
    }

    void Update()
    {
        transform.position = new Vector3(targetpos.x, -Mathf.Sin(Time.time) * Speed + targetpos.y, targetpos.z);
    }
}
