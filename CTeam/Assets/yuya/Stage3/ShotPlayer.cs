using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotPlayer : MonoBehaviour
{
    public GameObject shotObject;
    public float force = 10.0f;
    public Rigidbody rb;
    public int shotcount = 100;

    void Start()
    {
        rb = shotObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetButton("B"))
        {
            if(shotcount < 1)
            {
                return;
            }

            Instantiate(shotObject, transform.position + transform.forward + transform.up, transform.rotation);
            //Instantiate(shotObject, transform.position + transform.up / 1000, transform.rotation);
            shotcount -= 1; ;
        }
    }
}
