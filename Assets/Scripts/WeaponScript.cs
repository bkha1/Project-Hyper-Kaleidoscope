using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour {

    public Transform shotPrefab;
    public float shootingRate = .25f;
    private float shootCooldown;

    private ShotScript shot;
    private MoveScript shotMove;
    private Rigidbody2D shotRigid;

    //TODO: make the variables in the functions public variables for this script, then attack can be called using only a few functions
    //TODO: make it so that it adds a movescript if the attack wants the bullet to have a constant speed?

    //the weapon id will be used to identify what to activate
    public int weaponID = 0;

    // Use this for initialization
    void Start()
    {
        shootCooldown = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }
    }

    public bool CanAttack()
    {
        /*get
        {
            return shootCooldown <= 0f;
        }*/
        if (shootCooldown <= 0f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool CanAttack(int ID)
    {
        if (weaponID == ID)
        {
            return CanAttack();
        }
        else
        {
            return false;
        }
    }

    
    public void Attack(bool isEnemy)
    {
        if (CanAttack())
        {
            shootCooldown = shootingRate;
            var shotTransform = Instantiate(shotPrefab) as Transform;
            shotTransform.position = transform.position;

            shotTransform.rotation = transform.rotation;

            shotMove = shotTransform.gameObject.GetComponent<MoveScript>();
            if (shotMove != null)
            {
                shotMove.direction = transform.eulerAngles.z;
            }
            else//if there is no movescript attached
            {
                shotRigid = shotTransform.gameObject.GetComponent<Rigidbody2D>();
                if (shotRigid != null)
                {
                    Vector2 movement = new Vector2(Mathf.Cos(Mathf.Deg2Rad * transform.eulerAngles.z), Mathf.Sin(Mathf.Deg2Rad * transform.eulerAngles.z));
                    movement *= 1;
                    shotTransform.gameObject.rigidbody2D.velocity = movement;
                }
                //shotTransform.gameObject.AddComponent<MoveScript>();
                //shotMove = shotTransform.gameObject.GetComponent<MoveScript>();
                //shotMove.direction = transform.eulerAngles.z;
            }

            /*shot = shotTransform.gameObject.GetComponent<ShotScript>();

            if (shot != null)
            {
                shot.isEnemyShot = isEnemy;
            }*/
        }
    }

    //used to activate specific weapons
    public void Attack(bool isEnemy, int ID)
    {
        if (weaponID == ID)
        {
            Attack(isEnemy);
        }
    }//end Attack

    public void Attack(bool isEnemy, int ID, float speed)
    {
        if (weaponID == ID)
        {
            if (CanAttack())
            {
                shootCooldown = shootingRate;
                var shotTransform = Instantiate(shotPrefab) as Transform;
                shotTransform.position = transform.position;

                shotTransform.rotation = transform.rotation;
                //shotMove = shotTransform.gameObject.GetComponent<MoveScript>();
                //shotMove.direction = transform.eulerAngles.z;

                shotMove = shotTransform.gameObject.GetComponent<MoveScript>();
                if (shotMove != null)
                {
                    shotMove.direction = transform.eulerAngles.z;
                    shotMove.speed = speed;
                }
                else//if there is no movescript attached
                {
                    shotRigid = shotTransform.gameObject.GetComponent<Rigidbody2D>();
                    if (shotRigid != null)
                    {
                        Vector2 movement = new Vector2(Mathf.Cos(Mathf.Deg2Rad * transform.eulerAngles.z), Mathf.Sin(Mathf.Deg2Rad * transform.eulerAngles.z));
                        movement *= speed;
                        shotTransform.gameObject.rigidbody2D.velocity = movement;
                    }
                }

                /*shot = shotTransform.gameObject.GetComponent<ShotScript>();
                if (shot != null)
                {
                    shot.isEnemyShot = isEnemy;
                }*/

                /*MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();

                if (move != null)
                {
                    move.speed = speed;
                }*/
            }
        }
    }

    public void Attack(bool isEnemy, int ID, float speed, float size)
    {
        if (weaponID == ID)
        {
            if (CanAttack())
            {
                shootCooldown = shootingRate;
                var shotTransform = Instantiate(shotPrefab) as Transform;
                Vector3 tempScale = shotTransform.localScale;
                tempScale.x = size;
                tempScale.y = size;
                shotTransform.localScale = tempScale;
                shotTransform.position = transform.position;

                shotTransform.rotation = transform.rotation;
                //shotMove = shotTransform.gameObject.GetComponent<MoveScript>();
                //shotMove.direction = transform.eulerAngles.z;

                shotMove = shotTransform.gameObject.GetComponent<MoveScript>();
                if (shotMove != null)
                {
                    shotMove.direction = transform.eulerAngles.z;
                    shotMove.speed = speed;
                }
                else//if there is no movescript attached
                {
                    shotRigid = shotTransform.gameObject.GetComponent<Rigidbody2D>();
                    if (shotRigid != null)
                    {
                        Vector2 movement = new Vector2(Mathf.Cos(Mathf.Deg2Rad * transform.eulerAngles.z), Mathf.Sin(Mathf.Deg2Rad * transform.eulerAngles.z));
                        movement *= speed;
                        shotTransform.gameObject.rigidbody2D.velocity = movement;
                    }
                }

                /*shot = shotTransform.gameObject.GetComponent<ShotScript>();

                if (shot != null)
                {
                    shot.isEnemyShot = isEnemy;
                }*/

                /*MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();

                if (move != null)
                {
                    move.speed = speed;
                }*/
            }
        }
    }
}
