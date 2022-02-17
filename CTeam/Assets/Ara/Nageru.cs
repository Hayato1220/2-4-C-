using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nageru : MonoBehaviour
{
    public Transform oya;
    private SphereCollider sph;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        oya = GetComponent<Transform>();
        sph = GetComponent<SphereCollider>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyUp(KeyCode.Q))
        //{
        //    gameObject.AddComponent<Rigidbody>();

        //    rb.useGravity = true;

        //    this.gameObject.transform.parent = null;

        //    this.sph.isTrigger = false;

        //    rb.AddForce(Vector3.Lerp(transform.forward, transform.up, 1f) * 10f, ForceMode.Impulse);

        //}
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            if(Input.GetButton("A"))
            {
                this.sph.isTrigger = true;

                this.transform.parent = GameObject.Find("WeponBoal").transform;

                this.transform.localPosition = new Vector3(0.09f, -0.06f, 0f);
            }
        }
    }
}
