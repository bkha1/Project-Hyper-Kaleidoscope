using UnityEngine;
using System.Collections;

public class HomingBulletScript : MonoBehaviour {

    private float homingTimer = 100;//time the bullet has to home in, after this expires itll stop homing;default 5?
    private float homingCooldown;
    private bool isHoming;

    private float homingWait = 1;//determines how long it will wait before it starts homing
    private float homingSpeed = 3f;

    void Awake()
    {
        homingCooldown = homingTimer;
        isHoming = false;
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (homingWait <= 0)
        {
            if (homingCooldown > 0)
            {
                isHoming = true;
                homingCooldown -= Time.deltaTime;
            }
            else
            {
                isHoming = false;
            }
        }
        else
        {
            isHoming = false;
            homingWait -= Time.deltaTime;
        }

        //Debug.Log(homingCooldown);
	}

    void OnTriggerStay2D(Collider2D collider)
    {
        PlayerScript player = collider.gameObject.GetComponent<PlayerScript>();
        if (player != null)
        {
            if (isHoming)
            {
                //float tAngle = Vector3.Angle(Vector3.right, player.transform.position - transform.position) * -1;
                //Debug.Log(tAngle);
                /*var localTarget = transform.InverseTransformPoint(target.position);
                var targetAngle = Mathf.Atan2(localTarget.x, localTarget.z);
                 var targetAngle = Mathf.Atan2(localTarget.x, localTarget.z) * Mathf.Rad2Deg;*/
                Vector3 localTarget = transform.InverseTransformPoint(player.transform.position);
                float targetAngle = Mathf.Atan2(localTarget.y, localTarget.x);
                targetAngle *= Mathf.Rad2Deg;
                //Debug.Log(localTarget);
                //Debug.Log(targetAngle);

                Vector2 movement = new Vector2(Mathf.Cos(Mathf.Deg2Rad * targetAngle), Mathf.Sin(Mathf.Deg2Rad * targetAngle));//constant movement speed

                /*
                float tempX;
                float tempY;
                if (localTarget.x > localTarget.y)
                {
                    tempY = localTarget.y / Mathf.Abs(localTarget.x);
                    tempX = localTarget.x/ Mathf.Abs(localTarget.x);
                }
                else
                {
                    tempX = localTarget.x / Mathf.Abs(localTarget.y);
                    tempY = localTarget.y / Mathf.Abs(localTarget.y);
                }

                Vector2 movement = new Vector2(tempX, tempY);*/

                //Vector2 movement = new Vector2(localTarget.x,localTarget.y);//not constant speed
                //Debug.Log(movement);
                movement *= homingSpeed;
                //Debug.Log(movement);
                rigidbody2D.velocity = movement;
            }
        }
    }
}
