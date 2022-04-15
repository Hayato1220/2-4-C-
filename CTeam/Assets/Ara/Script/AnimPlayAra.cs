using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimPlayAra : MonoBehaviour
{
    private Animation anim;

    private bool getYumi;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();
        anim.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        getYumi = ToumeiAraYari.yari();

        if(getYumi == true)
        {
            anim.Play();
        }
    }
}
