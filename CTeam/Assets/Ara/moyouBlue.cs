using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moyouBlue : MonoBehaviour
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
        if (other.gameObject.tag == "Blue")
        {
            dousyoku = true;
        }
    }

    public static bool Blue()
    {
        return dousyoku;
    }
}
