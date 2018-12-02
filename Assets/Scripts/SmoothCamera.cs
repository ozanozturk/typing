using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    [SerializeField]
    private AnimationCurve curve;
    [SerializeField]
    private float transitionTime = 2;
    [SerializeField]
    private float cameraMovementRange = 4;
    private float currentTime = 0;
    private Vector3 startPos;
    private Vector3 targetPos;

	// Use this for initialization
	void Start ()
    {
        startPos = transform.position;
        targetPos = Vector3.zero;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Vector3.Distance(transform.position, targetPos) > 0.2f)
        {
            currentTime -= Time.deltaTime;
            transform.position = startPos + targetPos * (curve.Evaluate(currentTime / transitionTime));
        }
	}

    public void MoveCameraToTarget(Vector3 cameraDirection)
    {
        currentTime = transitionTime;
        startPos = transform.position;
        targetPos = cameraDirection * cameraMovementRange;
    }
}
