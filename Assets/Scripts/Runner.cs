using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{

    public float movementSpeed;

    public float jumpSpeed;

    public float boostHorizontal = 5, boostVertical = 15;

    public float gravitySpeed;

    [Header("Controls")]

    public KeyCode backwardButton;
    public KeyCode backwardButton2;


    public KeyCode jumpButton;

    CharacterController controller;

    Vector3 direction;

    float verticalSpeed;

    LevelManager levelManager;

    // Use this for initialization
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        controller = GetComponent<CharacterController>();
        direction = Vector3.right;
    }

    // Update is called once per frame
    void Update()
    {
        if (!controller.isGrounded)
        {
            verticalSpeed -= gravitySpeed * Time.deltaTime;
        }
        else
        {
            verticalSpeed = -gravitySpeed * Time.deltaTime;

            if (Input.GetKeyDown(jumpButton))
            {
                verticalSpeed = jumpSpeed;
            }
        }

        if (Input.GetKeyDown(backwardButton))
        {
            InvertDirection();
        }
        if (Input.GetKeyUp(backwardButton))
        {
            InvertDirection();
        }
        if (Input.GetKeyDown(backwardButton2))
        {
            InvertDirection();
        }
        if (Input.GetKeyUp(backwardButton2))
        {
            InvertDirection();
        }

        controller.Move((direction * movementSpeed + Vector3.up * verticalSpeed) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {
            levelManager.SwitchLevel();
        }
        if (other.tag == "Trap")
        {
            levelManager.RestartFromCheckpoint();
        }
        if (other.tag == "Collectible")
        {
            Destroy(other.gameObject);
            levelManager.IncreaseScore(10);
        }
        if (other.tag == "Checkpoint")
        {
            levelManager.CheckpointReached(other.transform.position + new Vector3(0, 0.5f, 0));
            Destroy(other.gameObject);
        }
        if (other.tag == "Booster")
        {
            verticalSpeed = boostVertical;
            controller.Move((direction * boostHorizontal + Vector3.up * verticalSpeed) * Time.deltaTime);
        }
        if (other.tag == "Inverter")
        {
            InvertDirection();
        }
    }

    private void InvertDirection()
    {
        if (direction == Vector3.right)
        {
            direction = Vector3.left;
        }
        else if (direction == Vector3.left)
        {
            direction = Vector3.right;
        }
    }
}
