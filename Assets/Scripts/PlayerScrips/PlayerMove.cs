using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public PlatformSpawner platformSpawner;
    public GameObject player;
    public GameObject startCollider;
    public LayerMask layerMask;

    public bool canMove;
    public bool canMoveForward;
    public bool canMoveBackwards;
    public bool canMoveRight;
    public bool canMoveLeft;

    public int movement = 0;
    public int colliderMovement;

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

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canMove == true)
        {
            Move();
        }
    }


    void Move()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            RayCastCheckForward();

            if (canMoveForward == true)
            {
                player.transform.position += new Vector3(0, 0, 1);
                movement++;
                colliderMovement++;
                if(colliderMovement > 3)
                {
                    startCollider.transform.position += new Vector3(0, 0, 1);
                }

                if (movement == 3)
                {
                    platformSpawner.EndlessSpawning();
                    return;
                }
                if (movement == 7)
                {
                    platformSpawner.EndlessDespawning();
                    movement = 0;
                }
                
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            RayCastCheckBackward();
            if (canMoveBackwards == true)
            {
                player.transform.position -= new Vector3(0, 0, 1);
                movement--;
                if (colliderMovement > 3)
                {
                    colliderMovement = 3;
                }
                colliderMovement--;
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            RayCastCheckRight();
            if(canMoveRight == true)
            player.transform.position += new Vector3(1, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            RayCastCheckLeft();
            if(canMoveLeft == true)
            player.transform.position -= new Vector3(1, 0, 0);
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

    
}
