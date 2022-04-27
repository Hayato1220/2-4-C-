using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTarget2 : MonoBehaviour
{
    public GameObject batu;
    public GameObject maru;

    public static bool target2;

    public static bool ok;

    int getcount;

    // Start is called before the first frame update
    void Start()
    {
        target2 = false;

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

            target2 = true;
            ok = true;
        }
    }

    public static bool GetTarget2()
    {
        return target2;
    }

    public static bool Getok2()
    {
        return ok;
    }
}
