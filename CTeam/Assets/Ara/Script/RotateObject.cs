using UnityEngine;
public class RotateObject : MonoBehaviour
{
    [SerializeField]
    Vector3 speed;
    void Update()
    {
        transform.Rotate(0f,0f,5f);
    }
}