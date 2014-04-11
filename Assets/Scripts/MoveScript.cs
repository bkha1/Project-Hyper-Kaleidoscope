using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour {

    public int speed = 1;
    public bool useDirection = true;
    public float direction;
    public bool isRigidbody = true;
    public bool applyVelocityConstantly = true;
    private Vector2 movement;

    // Use this for initialization
    void Start()
    {
        if (isRigidbody)
        {
            if (useDirection == false)
            {
                movement = new Vector2(Mathf.Cos(Mathf.Deg2Rad * transform.eulerAngles.z), Mathf.Sin(Mathf.Deg2Rad * transform.eulerAngles.z));
            }
            else
            {
                movement = new Vector2(Mathf.Cos(Mathf.Deg2Rad * direction), Mathf.Sin(Mathf.Deg2Rad * direction));
            }
            movement *= speed;
            rigidbody2D.velocity = movement;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(transform.rotation.z);
        //Debug.Log(rigidbody2D.velocity.ToString());
        if (!isRigidbody)
        {
            if (useDirection == false)
            {
                movement = new Vector2(Mathf.Cos(Mathf.Deg2Rad * transform.eulerAngles.z), Mathf.Sin(Mathf.Deg2Rad * transform.eulerAngles.z));
            }
            else
            {
                movement = new Vector2(Mathf.Cos(Mathf.Deg2Rad * direction), Mathf.Sin(Mathf.Deg2Rad * direction));
            }
            movement *= Time.deltaTime * speed;
            transform.position += (Vector3)movement;
        }
    }

    void FixedUpdate()
    {
        if (isRigidbody)
        {
            if (applyVelocityConstantly)
            {
                if (useDirection == false)
                {
                    movement = new Vector2(Mathf.Cos(Mathf.Deg2Rad * transform.eulerAngles.z), Mathf.Sin(Mathf.Deg2Rad * transform.eulerAngles.z));
                }
                else
                {
                    movement = new Vector2(Mathf.Cos(Mathf.Deg2Rad * direction), Mathf.Sin(Mathf.Deg2Rad * direction));
                }
                movement *= speed;
                rigidbody2D.velocity = movement;
            }

            /*
            //messing with addforce; probably will use this for something else?
            //better idea is to stop setting the velocity as a constant when it is detected that it touched something, and then set that velocity as an addforce
            //nevermind, setting velocity at start works
            
            rigidbody2D.AddForce(movement);

            
            //caps velocities
            if (rigidbody2D.velocity.x > movement.x)
            {
                Vector2 tempvel = rigidbody2D.velocity;
                tempvel.x = movement.x;
                rigidbody2D.velocity = tempvel;
            }

            if (rigidbody2D.velocity.y > movement.y)
            {
                Vector2 tempvel = rigidbody2D.velocity;
                tempvel.y = movement.y;
                rigidbody2D.velocity = tempvel;
            }*/
             
        }
    }
}
