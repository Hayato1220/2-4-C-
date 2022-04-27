using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTarget1 : MonoBehaviour
{
    public GameObject batu;
    public GameObject maru;

    public static bool target1;

    public static bool ok;

    int getcount;

    // Start is called before the first frame update
    void Start()
    {
        target1 = false;

        ok = false;

    }

    // Update is called once per frame
    void Update()
    {
        getcount = Seisei.okcount();

        if (getcount == 0)
        {
            ok = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Object")
        {
            batu.SetActive(false);
            maru.SetActive(true);
            Destroy(collision.gameObject);

            target1 = true;
            ok = true;
        }
    }

    public static bool GetTarget1()
    {
        return target1;
    }

    public static bool Getok1()
    {
        return ok;
    }
}
