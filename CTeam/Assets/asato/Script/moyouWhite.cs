using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moyouWhite : MonoBehaviour
{
    private static bool dousyoku;

    // Start is called before the first frame update
    void Start()
    {
        dousyoku = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "White")
        {
            dousyoku = true;
        }
    }

    public static bool White()
    {
        return dousyoku;
    }
}
