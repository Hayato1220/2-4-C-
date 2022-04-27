using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimPlayAra2 : MonoBehaviour
{
    private Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();
        anim.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("PlayAnim", 1);
    }

    void PlayAnim()
    {
        anim.Play();

    }
}