using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class ToPlayer : MonoBehaviour
{
    Vector3 vec;

    public PhysicMaterial ma;

    private CapsuleCollider myCollider;


    private void Update()
    {
        vec = transform.position;

        myCollider = GetComponent<CapsuleCollider>();

    }

    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "Object")
        {

            myCollider.material = ma;

        }
        else if(col.gameObject.tag == "Untagged")
        {
            myCollider.material = null;
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Object")
        {
            myCollider.material = null;
        }
    }
}