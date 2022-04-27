using UnityEngine;
public class RotateObject : MonoBehaviour
{
    [SerializeField]
    Vector3 speed;


    void Start()
    {

    }
    void Update()
    {
        transform.Rotate(speed);
    }
}