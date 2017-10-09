using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeLogic : MonoBehaviour
{
    public GameObject swinger;

    private LineRenderer line;

    private void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    private void Update ()
    {
        if (swinger.GetComponent<PlayerController>().attached)
        {
            GetComponent<LineRenderer>().enabled = true;

            line.SetPosition(0, swinger.transform.position);
            line.SetPosition(1, swinger.GetComponent<SpringJoint>().connectedAnchor);
        }
        else
        {
            GetComponent<LineRenderer>().enabled = false;
        }
	}
}
