using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Syutugen : MonoBehaviour
{
    public GameObject miti;
    public bool getAll;

    // Start is called before the first frame update
    void Start()
    {
        getAll = false;
    }

    // Update is called once per frame
    void Update()
    {
        getAll = TobiraBreak.Move();

        if(getAll == true)
        {
            miti.SetActive(true);
        }
    }
}
