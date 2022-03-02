using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public GameObject DestroyCube;

    private Rigidbody rb;

    bool speedflag = false;

    void Start()
    {
        rb = DestroyCube.transform.GetComponent<Rigidbody>();
    }

    void Update()
    {
        Debug.Log(rb.velocity.magnitude);

        if(rb.velocity.magnitude >= 3.0f)
        {
            speedflag = true;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ball")
        {

            if (speedflag == true)
            {

                Destroy(DestroyCube);

                Destroy(this.gameObject);
            }
        }
    }
}
