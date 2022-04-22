using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KesuAra : MonoBehaviour
{

    public static bool ok;

    int getcount;

    // Start is called before the first frame update
    void Start()
    {
        ok = false;
    }

    // Update is called once per frame
    void Update()
    {
        getcount = Seisei.okcount();

        if(getcount == 0)
        {
            ok = false;
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Object")
        {
            Destroy(collision.gameObject);

            ok = true;
        }

        if(collision.gameObject.tag == "Player")
        {

        }
    }

    public static bool Bynkie()
    {
        return ok;
    }
}
