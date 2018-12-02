using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    [Header("Key")]

    public KeyCode platformKey;

    public PlatformType platformType;

    GameObject visual;

    bool state = false;

    Renderer renderingComponent;

    LevelManager levelManager;

    bool triggered;

    // Use this for initialization
    void Start()
    {
        if (platformType == PlatformType.Hazard)
        {
            state = true;
        }
        if (platformType == PlatformType.StandardOn)
        {
            state = true;
        }
        renderingComponent = transform.GetComponentInChildren<Renderer>();
        visual = transform.Find("Visual").gameObject;
        levelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (platformType == PlatformType.Hazard)
        {
            state = true;
            visual.SetActive(state);
        }

        if (Input.GetKeyDown(platformKey) && renderingComponent.isVisible)
        {
            if (triggered != true)
            {
                triggered = true;
                levelManager.IncreaseScore(1);
            }
            if (platformType != PlatformType.Permanent || (platformType == PlatformType.Permanent && state != true))
            {
                state = !state;
                visual.SetActive(state);
            }
        }
    }
}
