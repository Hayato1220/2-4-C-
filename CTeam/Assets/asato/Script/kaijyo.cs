using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kaijyo : MonoBehaviour
{
    public GameObject tobira;

    private bool ok;

    private bool getRed;
    private bool getGreen;
    private bool getBlue;
    private bool getOrange;

    // Start is called before the first frame update
    void Start()
    {
        ok = false;
    }

    // Update is called once per frame
    void Update()
    {
        getRed = moyouRed.Red();

        getGreen = moyouGreen.Green();

        getBlue = moyouBlue.Blue();

        getOrange = moyouOrange.Orange();

        if (getRed == true /*&& getGreen == true && getBlue == true && getOrange == true*/)
        {
            Destroy(tobira);
        }
    }
}
