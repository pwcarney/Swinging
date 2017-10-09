using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [HideInInspector]
    public bool attached;

    public float speed;
    public float jump_power;
    private Transform ground_check;
    public LayerMask ground_mask;
    private Rigidbody body;

    private void Start()
    {
        body = GetComponent<Rigidbody>();
        ground_check = transform.GetChild(0).transform;
    }

    private void Update ()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, ground_mask))
            {
                attached = true;
                if (GetComponent<SpringJoint>() == null)
                {
                    SetSpring();
                }
                GetComponent<SpringJoint>().connectedAnchor = hit.point;
            }
        }
        else if (Input.GetMouseButton(1))
        {
            attached = false;
            Destroy(GetComponent<SpringJoint>());
        }
	}

    void FixedUpdate()
    {
        if (IsGrounded() && Input.GetButtonDown("Jump"))
        {
            body.AddForce(new Vector3(0, jump_power, 0));
        }

        float moveVertical = Input.GetAxisRaw("Vertical");
        Vector3 forward_movement = moveVertical * Camera.main.transform.forward;

        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        Vector3 side_movement = moveHorizontal * Camera.main.transform.right;

        Vector3 movement = forward_movement + side_movement;
        movement.Normalize();

        body.AddForce(movement * speed);
    }

    private void SetSpring()
    {
        SpringJoint joint = gameObject.AddComponent<SpringJoint>();
        joint.autoConfigureConnectedAnchor = false;
        joint.spring = 2;
    }

    private bool IsGrounded()
    {
        Collider[] overlaps = Physics.OverlapSphere(ground_check.position, 0.3f, ground_mask);
        if (overlaps.Length > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
