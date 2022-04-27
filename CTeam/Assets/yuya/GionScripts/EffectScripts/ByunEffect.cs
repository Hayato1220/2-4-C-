using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class ByunEffect : MonoBehaviour
{
    private GameObject byun_P;

    private GameObject childObjbyun;

    Ray ray;
    RaycastHit hit;

    void Start()
    {
        byun_P = Resources.Load("ByunTrail") as GameObject;
        childObjbyun = (GameObject)Instantiate(byun_P, this.transform.position, Quaternion.identity);
        childObjbyun.transform.parent = this.gameObject.transform;
    }

    void Update()
    {
        ray = new Ray(transform.position, -transform.up);

        if (Physics.Raycast(ray, out hit, 1.0f))
        {
            childObjbyun.SetActive(false);
            //Debug.Log(hit.collider.gameObject.transform.position);
            Debug.DrawRay(ray.origin, ray.direction, Color.red, 3.0f);
        }
        else
        {
            childObjbyun.SetActive(true);
        }

    }
}

