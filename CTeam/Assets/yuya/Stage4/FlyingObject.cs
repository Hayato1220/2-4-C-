using UnityEngine;
using System.Collections;
public class FlyingObject : MonoBehaviour
{
    void Update()
    {
        transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time, 10), transform.position.z);
    }
}