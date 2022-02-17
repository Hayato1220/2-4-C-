using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    private Rigidbody rb;
    private float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = 5.0f;
    }

    private void Update()
    {
        rb.velocity = transform.forward * speed;

        //if(transform.position.x >= 10 || transform.position.x <= -10 || transform.position.z >= 10 || transform.position.z <= -10)
        //{
        //    Destroy(gameObject);
        //}
    }
}
