using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public GameObject DestroyWall;

    float getCubeSpeed;

    void Start()
    {
        
    }

    void Update()
    {
        getCubeSpeed = Speed.CubeSpeed();
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Wall")
        {
            if(getCubeSpeed >= 10.0f)
            {
                Destroy(DestroyWall);

                Destroy(this.gameObject);
            }

        }
    }
}
