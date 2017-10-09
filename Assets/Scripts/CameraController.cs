using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    public float rotateSpeed = 5;
    Vector3 offset;

    void Start()
    {
        offset = target.transform.position - transform.position;
    }

    void LateUpdate()
    {
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        target.transform.Rotate(0, horizontal, 0);

        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        target.transform.Rotate(vertical, 0, 0);

        float desired_x = target.transform.eulerAngles.x;
        float desired_y = target.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(-desired_x, desired_y, 0);
        transform.position = target.transform.position - (rotation * offset);

        transform.LookAt(target.transform);
    }
}