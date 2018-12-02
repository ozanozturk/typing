using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformVisibility : MonoBehaviour
{

    public Platform platform;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("VisionTest"))
        {
            platform.enabled = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("VisionTest"))
        {
            platform.enabled = false;
        }
    }
}
