using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSpawner : MonoBehaviour
{
    [SerializeField, TextArea]
    private string word;
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private float distanceBetweenWords;


	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void SpawnWord()
    {
        Vector3 lastPosition = Vector3.zero;
        GameObject lastLetter = null;

        foreach (Platform item in FindObjectsOfType<Platform>())
        {
            if (item.transform.position.x > lastPosition.x)
            {
                lastLetter = item.gameObject;
                lastPosition = item.transform.position;
            }
        }

        MeshFilter meshFilter = lastLetter.GetComponentInChildren<MeshFilter>();

        Vector3 spawnPosition = lastPosition + Vector3.right * meshFilter.sharedMesh.bounds.extents.x * meshFilter.gameObject.transform.localScale.x;

        spawnPosition += Vector3.right * distanceBetweenWords;

        Debug.Log(spawnPosition);

        foreach (char c in word)
        {
            if (c != ' ')
            {
                string letter = c.ToString().ToUpper();

                meshFilter = prefab.GetComponentInChildren<MeshFilter>();
                spawnPosition += Vector3.right * meshFilter.sharedMesh.bounds.extents.x * meshFilter.gameObject.transform.localScale.x;
                GameObject currentLetter = Instantiate(prefab, spawnPosition, Quaternion.identity);

                if (c == '!')
                {
                    currentLetter.GetComponent<Platform>().platformKey = KeyCode.Exclaim;
                }
                else if (c == '?')
                {
                    currentLetter.GetComponent<Platform>().platformKey = KeyCode.Question;
                }
                else if (c== '.')
                {
                    currentLetter.GetComponent<Platform>().platformKey = KeyCode.Period;
                }
                else if (c == ',')
                {
                    currentLetter.GetComponent<Platform>().platformKey = KeyCode.Comma;
                }
                else if (c == ';')
                {
                    currentLetter.GetComponent<Platform>().platformKey = KeyCode.Semicolon;
                }
                else if (c == ':')
                {
                    currentLetter.GetComponent<Platform>().platformKey = KeyCode.Colon;
                }
                else if (c == '\'')
                {
                    currentLetter.GetComponent<Platform>().platformKey = KeyCode.Quote;
                }
                else
                {
                    currentLetter.GetComponent<Platform>().platformKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), letter);
                }

                currentLetter.GetComponentInChildren<TextMesh>().text = letter;
                meshFilter = currentLetter.GetComponentInChildren<MeshFilter>();
                spawnPosition += Vector3.right * meshFilter.sharedMesh.bounds.extents.x * meshFilter.gameObject.transform.localScale.x;
            }
            else
            {
                spawnPosition += Vector3.right * distanceBetweenWords;
            }
           
        }
    }
}
