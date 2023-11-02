using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Devin Monaghan, Robert Austin
/// 11/02/2023
/// Allows the player to move, jump, and pick up wumpas
/// handles collison and trigger interactions
/// </summary>

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 10f;
    public float deathYLevel = -3f;
    public int wumpaCollected = 0;
    public int lives = 3;
    public bool attacking = false;
    public bool coolDown = false;
    public int wumpaSpawnNumber;
   
    public GameObject wumpaPrefab;

    private Rigidbody rigidbodyRef;
    private Vector3 startPos;

    [SerializeField] private Material Green;
    [SerializeField] private Material Red;

    // Start is called before the first frame update
    void Start()
    {
        // gets the rigidbody componet of this object and stores a reference to it
        rigidbodyRef = GetComponent<Rigidbody>();

        startPos = transform.position;
        
        // set beginning color to green
        GetComponent<MeshRenderer>().material = Green;
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
        if (Input.GetKeyDown(KeyCode.E) && !attacking && !coolDown)
        {
            StartCoroutine(Attack());
        }

        // if the player has collected 100 wumpas then gain a life and remove wumpas
        if (wumpaCollected >= 100)
        {
            GainLife();
        }

        // if player falls below the death Y level they respawn
        if (transform.position.y <= deathYLevel)
        {
            LoseLife();
        }

        JumpAttack();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Picks up wumpa upon collision, adds to score and turns off picked up wumpa
        if (other.gameObject.tag == "Wumpa")
        {
            wumpaCollected++;
            other.gameObject.SetActive(false);
        }
        // on collision with regular enemy or shield enemy, kill enemy if attacking or die if not attacking
        if (other.gameObject.tag == "RegEnemy" || other.gameObject.tag == "SpikeEnemy")
        {
            if (attacking)
            {
                Destroy(other.gameObject);
            }
            else
            {
                LoseLife();
            }
        }
        // die on collision with shield enemy or spike
        if (other.gameObject.tag == "ShieldEnemy" || other.gameObject.tag == "Spikes")
        {
            LoseLife();
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

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Crate")
        {
            if (attacking)
            {
                SpawnWumpas(other.gameObject.transform.position);
                Destroy(other.gameObject);
            }
        }
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
    private void LoseLife()
    {
        lives--;
        transform.position = startPos;

        if (lives == 0)
        {
            // add code to end game by loading the game over scene
            Debug.Log("Game ends");
            SceneManager.LoadScene(2);
        }
    }

    // Makes the player gain a life
    private void GainLife()
    {
        lives++;
    }

    //sets the player into the attacking state
    IEnumerator Attack()
    {
        // put player in attacking state for 1 second
        attacking = true;
        GetComponent<MeshRenderer>().material = Red;
        yield return new WaitForSeconds(1f);
        // take player out of attacking state
        attacking = false;
        GetComponent<MeshRenderer>().material = Green;

        // put player in cooldown state for 1.5 seconds
        coolDown = true;
        yield return new WaitForSeconds(1.5f);
        coolDown = false;
        // currently the cooldown persists when the player respawns
    }

    // checks if the player has jumped on top of a destroyable object via raycast
    private void JumpAttack()
    {
        RaycastHit hit;
        // raycast upwards and return true if it hits an object
        // Raycast(startPos, direction, output hit, distance for ray)
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.4f))
        {
            // if jumping on a crate destroy the crate and spawn a random number of wumpas from 1-5
            if (hit.collider.tag == "Crate")
            {
                SpawnWumpas(hit.collider.gameObject.transform.position);
                Destroy(hit.collider.gameObject);
            }
            // if jumping on a regular enemy or shield enemy kill the enemy
            if (hit.collider.tag == "RegEnemy" || hit.collider.tag == "ShieldEnemy")
            {
                Destroy(hit.collider.gameObject);
            }
        }
    }

    // set number of spawning wumpas to a random int from 1 to 5
    private void WumpaNumber()
    {
        wumpaSpawnNumber = Random.Range(1, 6);
    }

    /// <summary>
    /// spawns a random number of wumpas at the position of the recently destroyed crate
    /// </summary>
    /// <param name="cratePos"> transform.position of the spawning wumpas </param>
    private void SpawnWumpas(Vector3 cratePos)
    {
        WumpaNumber();

        for (int count = 1; count <= wumpaSpawnNumber; count++)
        {
            GameObject wumpaInstance = Instantiate(wumpaPrefab, cratePos, transform.rotation);
        }
    }
}