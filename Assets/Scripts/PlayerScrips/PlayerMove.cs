using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public PlatformSpawner platformSpawner;
    public GameObject player;
    public GameObject startCollider;
    public LayerMask layerMask;
    public Scoring score;
    public Rigidbody rb;

    public bool canMove;
    public bool canMoveForward;
    public bool canMoveBackwards;
    public bool canMoveRight;
    public bool canMoveLeft;
    public bool moveForward;
    public bool moveBackwards;
    public bool moveRight;
    public bool moveLeft;

    public int movement = 0;
    public int colliderMovement;
    public float timeBetweenMoves;
    public int points;
    public int holdPoints;

    // Start is called before the first frame update
    void Start()
    {
        canMove = false;
        canMoveForward = true;
        canMoveBackwards = false;
        canMoveLeft = true;
        canMoveRight = true;
        startCollider.SetActive(true);
    
    }


    void Update()
    {
        if (canMove == true)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                //moveForward = true;
                Invoke("MoveDelayForward", timeBetweenMoves);
            }

            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                //moveBackwards = true;
                Invoke("MoveDelayBackward", timeBetweenMoves);
            }
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                //moveRight = true;
                Invoke("MoveDelayRight", timeBetweenMoves);
            }

            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                //moveLeft = true;
                Invoke("MoveDelayLeft", timeBetweenMoves);
            }
        }


    }
    void FixedUpdate()
    {
        if (canMove == true)
        {
            Move();
        }
    }


    void Move()
    {
        if (moveForward == true)
        {
            RayCastCheckForward();
            
            if (canMoveForward == true)
            {
                player.transform.position += new Vector3(0, 0, 1);
                movement++;
                if(holdPoints <= 0)
                {
                    points++;
                }
                else if( holdPoints > 0)
                {
                    holdPoints--;
                }
                colliderMovement++;
                if(colliderMovement > 3)
                {
                    startCollider.transform.position += new Vector3(0, 0, 1);
                }

                if (movement == 3)
                {
                    platformSpawner.EndlessSpawning();
                }
                if (movement == 7)
                {
                    platformSpawner.EndlessDespawning();
                    movement = 0;
                }
                
            }
            moveForward = false;
        }
        if (moveBackwards == true)
        {
            RayCastCheckBackward();
            
            if (canMoveBackwards == true)
            {
                player.transform.position -= new Vector3(0, 0, 1);
                movement--;
                holdPoints++;
                if (colliderMovement > 3)
                {
                    colliderMovement = 3;
                }
                colliderMovement--;
            }
            moveBackwards = false;
        }
        if (moveRight == true)
        {
            RayCastCheckRight();
            if(canMoveRight == true)
            player.transform.position += new Vector3(1, 0, 0);
            moveRight = false;
        }
        if (moveLeft == true)
        {
            RayCastCheckLeft();
            if(canMoveLeft == true)
            player.transform.position -= new Vector3(1, 0, 0);
            moveLeft = false;
        }
    }


    void RayCastCheckForward()
    {
        RaycastHit hitForward;

        if (Physics.Raycast(transform.position, transform.forward, out hitForward, 1f, layerMask))
        {
            Debug.DrawRay(transform.position, transform.forward * hitForward.distance, Color.yellow);
            Debug.Log(hitForward.transform.gameObject.name);

            if (hitForward.transform.gameObject.tag == "Obstacle")
            {
                canMoveForward = false;
            }

        }
        else
        {
            canMoveForward = true;
        }
    }

    void RayCastCheckBackward()
    {
        RaycastHit hitBackwards;

        if (Physics.Raycast(transform.position, -transform.forward, out hitBackwards, 1f, layerMask))
        {
            Debug.DrawRay(transform.position, transform.forward * hitBackwards.distance, Color.yellow);
            Debug.Log(hitBackwards.transform.gameObject.name);

            if (hitBackwards.transform.gameObject.tag == "Obstacle")
            {
                canMoveBackwards = false;
            }
        }
        else
        {
            canMoveBackwards = true;
        }
    }

    void RayCastCheckRight()
    {

        RaycastHit hitRight;

        if (Physics.Raycast(transform.position, transform.right, out hitRight, 1f, layerMask))
        {
            Debug.DrawRay(transform.position, transform.right * hitRight.distance, Color.yellow);
            Debug.Log(hitRight.transform.gameObject.name);

            if (hitRight.transform.gameObject.tag == "Obstacle" || hitRight.transform.gameObject.tag == "Boundary")
            {
                canMoveRight = false;
            }

        }
        else
        {
            canMoveRight = true;
        }
    }

    void RayCastCheckLeft()
    {

        RaycastHit hitLeft;

        if (Physics.Raycast(transform.position, -transform.right, out hitLeft, 1f, layerMask))
        {
            Debug.DrawRay(transform.position, -transform.right * hitLeft.distance, Color.yellow);
            Debug.Log(hitLeft.transform.gameObject.name);

            if (hitLeft.transform.gameObject.tag == "Obstacle" || hitLeft.transform.gameObject.tag == "Boundary")
            {
                canMoveLeft = false;
            }
            

        }
        else
        {
            canMoveLeft = true;
        }
    }

    public void MoveDelayForward()
    {
        moveForward = true;      
    }

    public void MoveDelayBackward()
    {
        moveBackwards = true;     
    }
    public void MoveDelayRight()
    {
        moveRight = true;      
    }
    public void MoveDelayLeft()
    {

        moveLeft = true;  
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Deathzone")
        {
            Death();
        }
    }

    public void Death()
    {
        canMove = false;
        this.gameObject.transform.SetParent(null);
        score.CheckHighScore();
        Invoke("StopFalling", 1f);
    }

    void StopFalling()
    {
        rb.useGravity = false;
        rb.velocity = Vector3.zero;
    }
}
