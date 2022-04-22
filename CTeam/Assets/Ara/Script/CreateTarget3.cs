using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTarget3 : MonoBehaviour
{
    public GameObject batu;
    public GameObject maru;

    public static bool target3;

    public static bool ok;

    int getcount;

    // Start is called before the first frame update
    void Start()
    {
        target3 = false;

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
        if (collision.gameObject.tag == "Object")
        {
            batu.SetActive(false);
            maru.SetActive(true);
            Destroy(collision.gameObject);

            target3 = true;
            ok = true;
        }
    }

    public static bool GetTarget3()
    {
        return target3;
    }

    public static bool Getok3()
    {
        return ok;
    }
}
