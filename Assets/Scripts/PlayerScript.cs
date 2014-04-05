using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    
    //public Vector2 speed = new Vector2(50, 50);
    private float moveSpeed = 10f;
    //private float maxSpeed = 50;
    private Vector2 movement;
    private HealthScript healthscript;
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

        if (Input.GetKey(KeyCode.Space))
        {
            moveSpeed = 15f;
        }
        else
        {
            moveSpeed = 10f;
        }
        moveController();

        //player dead
        if (healthscript.hp <= 0)
        {
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
        rotateObject();
        //moveController();

        rigidbody2D.velocity = movement;
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
    }
}
