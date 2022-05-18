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


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BreakCube")
        {
            Destroy(gameObject);

            ok = true;
        }
    }

    public static bool Bynkie()
    {
        return ok;
    }
}
