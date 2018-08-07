using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetAmbiance : MonoBehaviour
{    
	void Update ()
    {
        GetComponent<AudioSource>().volume = 1 - Mathf.Clamp01(transform.position.y / 100f);
	}
}
