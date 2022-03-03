using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    public GameObject DestroyWall;

    private Rigidbody rb;

    bool speedflag = false;

    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
    }

    void Update()
    {
        Debug.Log(rb.velocity.magnitude);

        if (rb.velocity.magnitude >= 3.0f)
        {
            speedflag = true;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Wall")
        {

            if (speedflag == true)
            {

                Destroy(DestroyWall);

                Destroy(this.gameObject);
            }
        }
    }
}
