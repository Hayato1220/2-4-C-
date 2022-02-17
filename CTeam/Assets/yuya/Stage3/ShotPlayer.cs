using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotPlayer : MonoBehaviour
{
    public GameObject shotObject;
    public float force = 10.0f;
    public Rigidbody rb;


    void Start()
    {
        rb = shotObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetButton("B"))
        {
            Instantiate(shotObject, transform.position + transform.forward + transform.up, transform.rotation);
            //Instantiate(shotObject, transform.position + transform.up / 1000, transform.rotation);
        }
    }
}
