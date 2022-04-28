using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class ByunEffect : MonoBehaviour
{
    private GameObject byun_P;
    private GameObject byun_P2;

    private GameObject childObjbyun;
    private GameObject childObjbyun2;

    Ray ray;
    RaycastHit hit;

    Ray ray2;

    void Start()
    {
        byun_P = Resources.Load("ByunTrail") as GameObject;
        childObjbyun = (GameObject)Instantiate(byun_P, this.transform.position, Quaternion.identity);
        childObjbyun.transform.parent = this.gameObject.transform;



    }

    void Update()
    {
        ray = new Ray(transform.position, -transform.up);

        if (Physics.Raycast(ray, out hit, 0.5f))
        {
            childObjbyun.SetActive(false);
            //Debug.Log(hit.collider.gameObject.transform.position);
            Debug.DrawRay(ray.origin, ray.direction, Color.red, 3.0f);
        }
        else
        {
            childObjbyun.SetActive(true);
            //if (Input.GetButtonDown("B"))
            //{
            //    childObjbyun2.SetActive(true);
            //}
        }

        ray2 = new Ray(transform.position, -transform.forward);

        //if (Physics.BoxCast(transform.position, Vector3.one * 0.5f, transform.forward, out hit, 1.0f))
        if(Physics.Raycast(ray2, out hit, 0.5f))
        {
            if (hit.collider.CompareTag("Player"))
            {
                if (Input.GetButtonDown("B"))
                {
                    byun_P2 = Resources.Load("byunEffect") as GameObject;
                    childObjbyun2 = (GameObject)Instantiate(byun_P2, this.transform.position + this.transform.forward * -0.5f, Quaternion.identity);
                    childObjbyun2.transform.parent = this.gameObject.transform;
                    Destroy(childObjbyun2, 1.0f);
                }
            }
            //Gizmos.DrawWireCube(transform.position, Vector3.one);
        }
        Debug.DrawRay(ray2.origin, ray2.direction, Color.red, 3.0f);
    }
}

