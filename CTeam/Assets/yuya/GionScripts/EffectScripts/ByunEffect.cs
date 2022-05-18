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
        /* 追尾するエフェクトが床についていていらた表示しないようにする */
        ray = new Ray(transform.position, -transform.up);

        if (Physics.Raycast(ray, out hit, 1.0f))
        {
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                childObjbyun.SetActive(false);
                Debug.DrawRay(ray.origin, ray.direction, Color.red, 3.0f);
            }
        }
        else
        {
            childObjbyun.SetActive(true);
        }
    }
}

