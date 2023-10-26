using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Devin Monaghan, Robert Austin
/// 10/26/2023
/// Allows the player to move, jump, and pick up wumpas
/// </summary>

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 10f;
    public float deathYLevel = -3f;
    public int wumpaCollected = 0;
    public int lives = 3;
    public bool attacking = false;


    private Rigidbody rigidbodyRef;
    private Vector3 startPos;

    [SerializeField] private Material myMaterial;

    // Start is called before the first frame update
    void Start()
    {
        // gets the rigidbody componet of this object and stores a refercne to it
        rigidbodyRef = GetComponent<Rigidbody>();

        startPos = transform.position;
        myMaterial.color = Color.green;

    }

    // Update is called once per frame
    void Update()
    {
        // if the player press the "a" key move left
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        // if the player press the "d" key move right
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        // if the player press the "w" key move forward
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;
        }
        // if the player press the "s" key move backward
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.back * speed * Time.deltaTime;
        }
        // if the player presses the spacebar then jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        // if the player presses the "e" then attack
        if (Input.GetKeyDown(KeyCode.E))
        {
            Attack();
        }

        // if the player has collected 100 wumpas then gain a life and remove wumpas
        if (wumpaCollected >= 100)
        {
            GainLife();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Picks up coins upon collision, adds to score and turns off picked up coin
        if (other.gameObject.tag == "Wumpa")
        {
            wumpaCollected++;
            other.gameObject.SetActive(false);
        }

        // Resets player's position upon collision with obstacles like enemies or black holes
        if (other.gameObject.tag == "Obstacle")
        {
            if (attacking)
            {
                Destroy(other.gameObject);
            }
            else
            {
                Respawn();
            }
        }

        if (other.gameObject.tag == "RegEnemy")
        {
            if (attacking)
            {
                Destroy(other.gameObject);
            }
            else
            {
                Respawn();
            }
        }

        /*
        // on collsion with a portal teleport to portal's set teleport position
        // reset spawn postion to reflect new level
        if (other.gameObject.tag == "Portal")
        {
            transform.position = other.gameObject.GetComponent<Portal>().teleportPoint.transform.position;
            startPos = transform.position;
        }
        */
    }

    // makes the player jump through adding force
    private void Jump()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.3f))
        {
            rigidbodyRef.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            Debug.Log("Player is touching the ground so jump");
        }
        else
        {
            Debug.Log("Player is not touching the ground so can't jump");
        }
    }

    // Respawns the player to their current level's starting position
    // Makes the player lose a life
    private void Respawn()
    {
        lives--;
        transform.position = startPos;

        if (lives == 0)
        {
            // add code to end game by loading the game over scene
            Debug.Log("Game ends");
            //SceneManager.LoadScene(1);
        }
    }

    // Makes the player gain a life
    private void GainLife()
    {
        lives++;
    }

    //makes the player attack
    private void Attack()
    {
        attacking = true;
        myMaterial.color = Color.red;







        myMaterial.color = Color.green;
        attacking = false;
    }
}