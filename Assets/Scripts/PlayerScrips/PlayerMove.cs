using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMove : MonoBehaviour
{
    public PlatformSpawner platformSpawner;
    public GameObject player;
    public GameObject startCollider;
    public GameObject startColliderBeginning;
    public LayerMask layerMask;
    public Scoring score;
    public Rigidbody rb;
    public GameObject birdMesh;
    public Vector3 prevPos;
    public float jumpSpeed = 20;
    public float jumpHeight = 0.6f;

    public bool canMove;
    public bool canMoveForward;
    public bool canMoveBackwards;
    public bool canMoveRight;
    public bool canMoveLeft;
    public bool moveForward;
    public bool moveBackwards;
    public bool moveRight;
    public bool moveLeft;
    public bool backwardsDeath;
    public bool cameraFreeze;
    public bool eagleAttack;


    public int movement = 0;
    public int colliderMovement;
    public float timeBetweenMoves;
    public int points;
    public int holdPoints;
    public float cameraMove;

    public Text scoreText;

    public float cubeSize = 0.1f;
    public int cubeNum = 3;

    float cubesPivotDistance;
    Vector3 cubesPivot;

    public float explosionForce = 25;
    public float explosionRadius = 4f;
    public float explosionUpward = 0.4f;
    public Vector3 explosionSource;

    public Material matBird;
    public Material matSplash;


    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(480, 800, false);
        cameraFreeze = true;
        canMove = false;
        canMoveForward = true;
        canMoveBackwards = false;
        canMoveLeft = true;
        canMoveRight = true;
        backwardsDeath = false;
        eagleAttack = false;
        startCollider.SetActive(true);
        startColliderBeginning.SetActive(true);
        points = 0;
        scoreText.text = "Score: " + points;
        scoreText.gameObject.SetActive(false);

        cubesPivotDistance = cubeSize * cubeNum / 2;
        cubesPivot = new Vector3(cubesPivotDistance, cubesPivotDistance, cubesPivotDistance);
    }


    void Update()
    {
        if (canMove == true)
        {
            if (cameraFreeze == false)
            {
                cameraMove += Time.deltaTime;
            }
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
            birdMesh.transform.eulerAngles = new Vector3(0, 0, 0);
            RayCastCheckForward();
            
            if (canMoveForward == true)
            {
                prevPos = Vector3.zero - new Vector3(0, 0, 1);
                player.transform.position += new Vector3(0, 0, 1);
                StartCoroutine(MeshMove());
                movement++;
                cameraMove = 0;
                if(cameraFreeze == true)
                {
                    cameraFreeze = false;
                }
                if(holdPoints <= 0)
                {
                    points++;
                    scoreText.text = "Score: " + points;
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
                    if(backwardsDeath == false)
                    {
                        backwardsDeath = true;
                        startColliderBeginning.SetActive(false);
                    }
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
            birdMesh.transform.eulerAngles = new Vector3(0, 180, 0);
            RayCastCheckBackward();
            
            if (canMoveBackwards == true)
            {
                prevPos = Vector3.zero + new Vector3(0, 0, 1);
                player.transform.position -= new Vector3(0, 0, 1);
                StartCoroutine(MeshMove());
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
            birdMesh.transform.eulerAngles = new Vector3(0, 90, 0);
            RayCastCheckRight();
            if(canMoveRight == true)
            {
                prevPos = Vector3.zero - new Vector3(1, 0, 0);
                player.transform.position += new Vector3(1, 0, 0);
                StartCoroutine(MeshMove());
            }
            moveRight = false;
        }
        if (moveLeft == true)
        {
            birdMesh.transform.eulerAngles = new Vector3(0, -90, 0);
            RayCastCheckLeft();
            if(canMoveLeft == true)
            {
                prevPos = Vector3.zero + new Vector3(1, 0, 0);
                player.transform.position -= new Vector3(1, 0, 0);
                StartCoroutine(MeshMove());
            }
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
        if (other.gameObject.tag == "Vehicle")
        {
            Death();
            birdMesh.SetActive(false);
            explosionSource = Vector3.Lerp(transform.position, other.gameObject.transform.position, 0.1f);
            ExplosionCar();
        }
        else if (other.gameObject.tag == "Deathzone")
        {
            Death();
            ExplosionWater();
        }
        else if(other.gameObject.tag == "RearDeathZone")
        {
            canMove = false;
            cameraFreeze = true;
            cameraMove = 0;
            eagleAttack = true;
            //Death();
        }
    }

    public void Death()
    {
        canMove = false;
        cameraFreeze = true;
        cameraMove = 0;
        this.gameObject.transform.SetParent(null);
        this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
        score.CheckHighScore();
        Invoke("StopFalling", 1f);
    }

    void StopFalling()
    {
        rb.useGravity = false;
        rb.velocity = Vector3.zero;
    }
    void Explode(int x, int y, int z)
    {
        GameObject cube;
        cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.layer = 10;
        cube.transform.position = transform.position + new Vector3(cubeSize * x, cubeSize * y, cubeSize * z) - cubesPivot;
        cube.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);
        cube.AddComponent<Rigidbody>();
        cube.GetComponent<Rigidbody>().mass = cubeSize;
        cube.GetComponent<Renderer>().material = matBird;
        cube.AddComponent<DestroyOnTime>();
    }

    void ExplosionCar()
    {
        for (int x = 0; x < cubeNum; x++)
        {
            for (int y = 0; y < cubeNum; y++)
            {
                for (int z = 0; z < cubeNum; z++)
                {
                    Explode(x, y, z);
                }
            }
        }

        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, explosionSource, explosionRadius, explosionUpward);
            }
        }

    }

    void Splash(int x, int y, int z)
    {
        GameObject cube;
        cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        cube.transform.position = transform.position + new Vector3(cubeSize * x, cubeSize * y, cubeSize * z) - cubesPivot;
        cube.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);
        cube.AddComponent<Rigidbody>();
        cube.GetComponent<Rigidbody>().mass = cubeSize;
        cube.GetComponent<Renderer>().material = matSplash;
        cube.AddComponent<DestroyOnTime>();
    }

    void ExplosionWater()
    {
        for (int x = 0; x < cubeNum; x++)
        {
            for (int y = 0; y < cubeNum; y++)
            {
                for (int z = 0; z < cubeNum; z++)
                {
                    Splash(x, y, z);
                }
            }
        }

        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, explosionUpward);
            }
        }

    }


    IEnumerator MeshMove()
    {
        birdMesh.transform.localPosition = prevPos;
        Vector3 currentPos = prevPos;
        float t = 0;
        while (birdMesh.transform.localPosition != Vector3.zero)
        {
            t += Time.deltaTime * jumpSpeed;
            currentPos = Vector3.Lerp(prevPos, Vector3.zero, t);
            if (t < .5f)
            {
                currentPos.y = Mathf.Lerp(0f, jumpHeight, t * 2);
            }
            else
            {
                currentPos.y = Mathf.Lerp(jumpHeight, 0f, (t * 2) - 1f);
            }
            birdMesh.transform.localPosition = currentPos;
            yield return null;
        }
        yield return null;
    }
}

