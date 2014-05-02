using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    
    //public Vector2 speed = new Vector2(50, 50);
    private float moveSpeed = 10f;
    //private float maxSpeed = 50;
    private Vector2 movement;
    private HealthScript healthscript;

    private float respawnCooldown = 0;
    private bool isRespawning = false;
    private Vector2 lastVelocity = new Vector2(0, 0);

    void Awake()
    {
        healthscript = GetComponent<HealthScript>();
    }

	// Use this for initialization
	void Start () {
        //Screen.lockCursor = true;
	}
	
	// Update is called once per frame
	void Update () {
        //rotateObject();
        //moveController();

        if (!isRespawning)
        {
            if (Input.GetButton("Jump") == true)//Input.GetKey(KeyCode.Space))
            {
                moveSpeed = 15f;
                //Debug.Log("fjdsakl;");
            }
            else
            {
                moveSpeed = 10f;
            }
            moveController();
        }

        //player dead
        if (healthscript.hp <= 0 && !isRespawning)
        {
            CheckpointScript[] checks = FindObjectsOfType(typeof(CheckpointScript)) as CheckpointScript[];
            foreach (CheckpointScript c in checks)
            {
                if (c.isActive)
                {
                    GetComponentInChildren<TrailRenderer>().enabled = false;

                    SpecialEffectsScript.Instance.spawnPlayerRagdoll(gameObject.transform.position, gameObject.transform.localScale, gameObject.transform.eulerAngles, lastVelocity);

                    Vector3 tempPos = gameObject.transform.position;
                    tempPos.x = c.transform.transform.position.x;
                    tempPos.y = c.transform.transform.position.y;
                    gameObject.transform.position = tempPos;
                    gameObject.rigidbody2D.velocity = new Vector2(0, 0);
                    //GetComponentInChildren<TrailRenderer>().enabled = true;

                    //instantly transports camera to where the checkpoint is,doesnt work, yet
                    /*Camera.main.GetComponent<SmoothFollow2D>().enabled = false;
                    tempPos = Camera.main.transform.position;
                    tempPos.x = c.transform.transform.position.x;
                    tempPos.y = c.transform.transform.position.y;
                    Camera.main.transform.position = tempPos;
                    */
                    Camera.main.GetComponent<SmoothFollow2D>().focusCamera();
                    break;
                }
            }
            //healthscript.hp = 1;
            respawnCooldown = .25f;
            isRespawning = true;
        }

        if (isRespawning)
        {
            respawnCooldown -= Time.deltaTime;
            if (respawnCooldown <= 0)
            {
                isRespawning = false;
                GetComponentInChildren<TrailRenderer>().enabled = true;
                healthscript.hp = 1;
                //Camera.main.GetComponent<SmoothFollow2D>().enabled = true;
            }
        }
	}

    void FixedUpdate()
    {
        /*if (Input.GetKey(KeyCode.Space))
        {
            moveSpeed = 15f;
        }
        else
        {
            moveSpeed = 10f;
        }*/
        if (!isRespawning)
        {
            rotateObject();

            rigidbody2D.velocity = movement;
        }
    }

    void LateUpdate()
    {
        //records velocity at the end of a frame
        lastVelocity = rigidbody2D.velocity;
    }

    void rotateObject()
    {
        transform.Rotate(0, 0, -100 * Time.deltaTime);
    }

    void moveController()
    {
        //Screen.lockCursor = true;
        
        //float inputX = Input.GetAxis("Mouse X");
        //float inputY = Input.GetAxis("Mouse Y");

        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        float moveX = inputX * moveSpeed;
        float moveY = inputY * moveSpeed;
        //Debug.Log(moveX);
        /*
        if (moveX > maxSpeed)
        {
            moveX = maxSpeed;
        }
        else if (moveX < (maxSpeed * -1))
        {
            moveX = maxSpeed*-1;
        }
        if (moveY > maxSpeed)
        {
            moveY = maxSpeed;
        }
        else if (moveY < (maxSpeed * -1))
        {
            moveY = maxSpeed * -1;
        }*/
        
        movement = new Vector2(moveX, moveY);//inputX * moveSpeed, inputY * moveSpeed);
        //transform.position += (Vector3)movement;
        //rigidbody2D.velocity = movement;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        WallScript wall = collider.gameObject.GetComponent<WallScript>();
        if (wall != null)
        {
            //Debug.Log("HI! I AM A WALL! NICE TO MEET YOU!");
        }

        CheckpointScript check = collider.gameObject.GetComponent<CheckpointScript>();
        if (check != null)
        {
            if (check.isActive == false)
            {
                //make the other checkpoints inactive
                CheckpointScript[] checks = FindObjectsOfType(typeof(CheckpointScript)) as CheckpointScript[];
                foreach (CheckpointScript c in checks)
                {
                    c.isActive = false;
                }

                check.isActive = true;
            }

        }
    }
}
