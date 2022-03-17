using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameObject elevator;
    private float speed = 3.0F;
    private float rotateSpeed = 3.0F;

    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);

        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float curSpeed = speed * Input.GetAxis("Vertical");
        controller.SimpleMove(forward * curSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Area")
        {
            if (elevator.GetComponent<ElevatorMove>().is2ndFloor == false)
            {
                elevator.GetComponent<ElevatorMove>().MoveUp();
            }

            if (elevator.GetComponent<ElevatorMove>().is2ndFloor == true)
            {
                elevator.GetComponent<ElevatorMove>().MoveDown();
            }
        }
    }
}