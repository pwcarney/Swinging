using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCheck : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Building")
        {
            GetComponentInParent<PlayerController>().IsTouchingWall = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Building")
        {
            GetComponentInParent<PlayerController>().IsTouchingWall = false;
        }
    }
}
