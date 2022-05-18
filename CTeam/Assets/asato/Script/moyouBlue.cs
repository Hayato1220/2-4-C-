using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moyouBlue : MonoBehaviour
{
    public GameObject spot;

    private static bool dousyoku;

    void Start()
    {
        dousyoku = false;

        spot.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Blue")
        {
            spot.SetActive(true);

            dousyoku = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Blue")
        {
            spot.SetActive(false);

            dousyoku = false;
        }
    }



    public static bool Blue()
    {
        return dousyoku;
    }
}
