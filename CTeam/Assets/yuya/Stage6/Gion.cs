using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gion : MonoBehaviour
{
    private GameObject obj;

    private BoxCollider ObjCollider;

    public PhysicMaterial slip;

    private int number = 0;

    private bool subeflag = true;  //すべすべ
    private bool huwaflag = false;  //ふわふわ
    private bool baraflag = false;  //バラバラ
    private bool byunflag = false;  //ビューン

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetButton("X")){
            number++;
            if(number >= 4)
            {
                number = 0;
            }
        }
        GionChange();
    }

    void OnCollisionStay(Collision other)
    {


        if (other.gameObject.tag == "Object")
        {
            ObjCollider = other.gameObject.GetComponent<BoxCollider>();

            Debug.Log(ObjCollider);


            //すべすべにする
            if (Input.GetButton("B"))
            {
                ObjCollider.material = slip;
            }

        }
    }

    void GionChange()
    {
        switch (number)
        {
            case 0:
                Debug.Log(subeflag);
                break;
            case 1:
                Debug.Log(huwaflag);
                break;
            case 2:
                Debug.Log(baraflag);
                break;
            case 3:
                Debug.Log(byunflag);
                break;
        }
    }
}
