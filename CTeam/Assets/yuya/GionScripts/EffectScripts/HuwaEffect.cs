using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class HuwaEffect : MonoBehaviour
{
    private GameObject huwa_P;

    private GameObject childObjhuwa;

    Ray ray;
    RaycastHit hit;

    void Start()
    {
        huwa_P = Resources.Load("HuwaEffect") as GameObject;
        childObjhuwa = (GameObject)Instantiate(huwa_P, this.transform.position + this.transform.up * -0.49f, Quaternion.identity);
        childObjhuwa.transform.parent = this.gameObject.transform;
    }

    void Update()
    {
        ray = new Ray(transform.position, -transform.up);

        if (Physics.Raycast(ray, out hit, 1.0f))
        {
            childObjhuwa.SetActive(false);
            //Debug.Log(hit.collider.gameObject.transform.position);
            Debug.DrawRay(ray.origin, ray.direction, Color.red, 3.0f);
        }
        else
        {
            childObjhuwa.SetActive(true);
        }
    }
}
