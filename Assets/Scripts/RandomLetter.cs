using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomLetter : MonoBehaviour
{
    public float timerInSeconds = 2;
    public bool changeLetter = false;
    private float currentTimer;
    private Platform platform;
    private TextMesh letterDisplay;

    Renderer renderingComponent;

    // Use this for initialization
    void Start ()
    {
        platform = GetComponent<Platform>();
        letterDisplay = GetComponentInChildren<TextMesh>();
        renderingComponent = transform.GetComponentInChildren<Renderer>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (renderingComponent.isVisible)
        {
            currentTimer -= Time.deltaTime;
            if (currentTimer <= 0)
            {
                //ASCII Letters 65 - 90 are uppercase letters
                char letter = (char)Random.Range(65, 91);

                if (changeLetter)
                {
                    platform.platformKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), letter.ToString());
                }

                letterDisplay.text = letter.ToString();

                currentTimer = timerInSeconds;
            }
        }
	}

    private void OnBecameVisible()
    {
        currentTimer = timerInSeconds;
    }
}
