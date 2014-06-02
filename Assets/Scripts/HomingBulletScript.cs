using UnityEngine;
using System.Collections;

public class HomingBulletScript : MonoBehaviour {

    private float homingTimer = 100;//time the bullet has to home in, after this expires itll stop homing
    private float homingCooldown;
    private bool isHoming;

    void Awake()
    {
        homingCooldown = homingTimer;
        isHoming = true;
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (homingCooldown > 0)
        {
            homingCooldown -= Time.deltaTime;
        }
        else
        {
            isHoming = false;
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

                Vector2 movement = new Vector2(localTarget.x,localTarget.y);
                rigidbody2D.velocity = movement;
            }
        }
    }
}
