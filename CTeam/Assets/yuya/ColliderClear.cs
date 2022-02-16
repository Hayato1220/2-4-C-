using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderClear : MonoBehaviour
{
    public GameObject Player;

    void OnCollisionStay(Collision other)
    {
        if (Input.GetButton("B"))
        {
            if (other.gameObject.tag == "Wall")
            {
                //触れている間、壁をすり抜ける
                Player.layer = 11;
            }
        }
    }
}