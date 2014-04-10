using UnityEngine;
using System.Collections;

public class ShotScript : MonoBehaviour {

    public int damage = 1;
    public bool isEnemyShot = false;
    //public Transform wallEffectPrefab;
    private Vector2 lastVelocity = new Vector2(0, 0);

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 20);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void LateUpdate()
    {
        //records velocity at the end of a frame
        lastVelocity = rigidbody2D.velocity;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        WallScript wall = collider.gameObject.GetComponent<WallScript>();
        if (wall != null)
        {
            //NOTE: SHOULD PROBABLY MOVE THIS TO THE BULLET'S OWN SCRIPT?
            MoveScript move = GetComponent<MoveScript>();
            if(move!=null)
            {
                //float tempdeg = Mathf.Atan2(rigidbody2D.velocity.y, rigidbody2D.velocity.x) * Mathf.Rad2Deg;
                float tempdeg = Mathf.Atan2(lastVelocity.y, lastVelocity.x) * Mathf.Rad2Deg;
                //Debug.Log(lastVelocity.ToString());
                //tempdeg += 90;
                //Debug.Log(tempdeg);
                //Quaternion tempq = Quaternion.AngleAxis(tempdeg, Vector3.forward);
                SpecialEffectsScript.Instance.playHexagonConeEffect(transform.position, new Vector3(0,0,tempdeg), transform.localScale);
            }
            else
            {
                Debug.Log("cant instantiate effect");
            }
            Destroy(gameObject);
        }
    }

    /*void OnCollisionEnter2D(Collision2D collision)
    {
        WallScript wall = collision.gameObject.GetComponent<WallScript>();
        if (wall != null)
        {
            Debug.Log("collision");
        }
    }*/
}
