using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TobiraBreak : MonoBehaviour
{
    public  static bool Alltarget;

    public bool get1;
    public bool get2;
    public bool get3;

    public GameObject precube;

    // Start is called before the first frame update
    void Start()
    {
        Alltarget = false;
    }

    // Update is called once per frame
    void Update()
    {
        get1 = CreateTarget1.GetTarget1();
        get2 = CreateTarget2.GetTarget2();
        get3 = CreateTarget3.GetTarget3();

        if(get1 == true && get2 == true && get3 == true)
        {
            Alltarget = true;
        }
        if(Alltarget == true)
        {
            Destroy(gameObject);
            Destroy(precube);
        }
    }

    public static bool Move()
    {
        return Alltarget;
    }
}
