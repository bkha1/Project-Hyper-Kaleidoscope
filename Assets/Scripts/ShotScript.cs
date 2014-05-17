using UnityEngine;
using System.Collections;

public class ShotScript : MonoBehaviour {

    public int damage = 1;
    //public bool isEnemyShot = false;
    //public Transform wallEffectPrefab;

    public bool inMutualLayer = false;

    public bool terminateOnWall = true;
    public bool terminateOnShot = true;//is this necessary?
    public bool terminateOnEnemy = true;
    public bool terminateOnPlayer = false;

    //public bool hasEffect = true;
    public int effectID = 0;
    public int particleID = 0;

    private Vector2 lastVelocity = new Vector2(0, 0);
    private float longevity = 20;
    private bool addFade = false;
    private ParticleShooterScript[] particles;

    void Awake()
    {
        particles = GetComponentsInChildren<ParticleShooterScript>();

        if (inMutualLayer)
        {
            gameObject.layer = LayerMask.NameToLayer("Mutual");
        }
    }

	// Use this for initialization
	void Start () {
        Destroy(gameObject, longevity);
	}
    
	// Update is called once per frame
	void Update () {
        longevity -= Time.deltaTime;
        if (longevity <= 3 && !addFade)
        {
            gameObject.AddComponent<ObjectFadeAwayScript>();
            ObjectFadeAwayScript fadeScript = GetComponent<ObjectFadeAwayScript>();
            if (fadeScript != null)
            {
                fadeScript.fadeCooldown = 3;
            }
            addFade = true;
        }

        if (inMutualLayer)
        {
            gameObject.layer = LayerMask.NameToLayer("Mutual");
        }
        else
        {
            gameObject.layer = LayerMask.NameToLayer("Default");
        }
	}

    void LateUpdate()
    {
        //records velocity at the end of a frame
        lastVelocity = rigidbody2D.velocity;
    }

    /*void OnTriggerEnter2D(Collider2D collider)
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
                SpecialEffectsScript.Instance.playHexagonConeEffect(new Vector3(transform.position.x,transform.position.y,6), new Vector3(0,0,tempdeg), transform.localScale);

                //Vector3 tempPos = transform.localScale;
                //tempPos.z = 0;
                //tempPos = tempPos / 10;

                //SpecialEffectsScript.Instance.spawnNeutral4StarGray(new Vector3(transform.position.x - tempPos.x,transform.position.y + tempPos.y,transform.position.z), new Vector3(.7f,.7f,1), new Vector2(-10,10));
                //SpecialEffectsScript.Instance.spawnNeutral4StarGray(transform.position, new Vector3(.7f, .7f, 1), new Vector2(-10, -10));
                //SpecialEffectsScript.Instance.spawnNeutral4StarGray(transform.position, new Vector3(.7f, .7f, 1), new Vector2(10, -10));
                //SpecialEffectsScript.Instance.spawnNeutral4StarGray(transform.position, new Vector3(.7f, .7f, 1), new Vector2(10, 10));

                //SpecialEffectsScript.Instance.spawnNeutral4StarGray(transform.position, new Vector3(.7f, .7f, 1), new Vector2(0, 0));
                //SpecialEffectsScript.Instance.spawnNeutral4StarGray(transform.position, new Vector3(.7f, .7f, 1), new Vector2(0, 0));
                //SpecialEffectsScript.Instance.spawnNeutral4StarGray(transform.position, new Vector3(.7f, .7f, 1), new Vector2(0, 0));
                //SpecialEffectsScript.Instance.spawnNeutral4StarGray(transform.position, new Vector3(.7f, .7f, 1), new Vector2(0, 0));
                //rigidbody2D.AddForceAtPosition(new Vector2(1, 0), transform.position);

                foreach (ParticleShooterScript particle in particles)
                {
                    float tangle = particle.transform.eulerAngles.z;

                    //vary the angles
                    if (Random.Range(0, 2) == 0)
                    {
                        tangle += Random.Range(0, 20);
                    }
                    else
                    {
                        tangle -= Random.Range(0, 20);
                    }

                    Vector2 tempMovement = new Vector2(Mathf.Cos(Mathf.Deg2Rad * tangle), Mathf.Sin(Mathf.Deg2Rad * tangle));

                    if (Random.Range(0, 100) < 10)
                    {
                        SpecialEffectsScript.Instance.spawnNeutral4StarGray(particle.transform.position, new Vector3(.7f, .7f, 1), tempMovement * 12);
                    }
                    else
                    {
                        if (Random.Range(0, 2) == 0)
                        {
                            SpecialEffectsScript.Instance.spawnNeutral4StarRed1(particle.transform.position, new Vector3(.7f, .7f, 1), tempMovement * 12);
                        }
                        else
                        {
                            SpecialEffectsScript.Instance.spawnNeutral4StarRed2(particle.transform.position, new Vector3(.7f, .7f, 1), tempMovement * 12);
                        }
                    }
                }
            }
            else
            {
                Debug.Log("cant instantiate effect");
            }
            Destroy(gameObject);
        }
    }*/

    

    void OnCollisionEnter2D(Collision2D collider)
    {
        
        
        
        if (terminateOnWall)
        {
            WallScript wall = collider.gameObject.GetComponent<WallScript>();
            if (wall != null)
            {
                selfTerminate();
            }

        }

        if (terminateOnShot)
        {
            ShotScript otherShot = collider.gameObject.GetComponent<ShotScript>();
            if (otherShot != null)
            {
                selfTerminate();
            }
        }

        if (terminateOnEnemy)
        {
            HealthScript healthsc = collider.gameObject.GetComponent<HealthScript>();
            if (healthsc != null)
            {
                if (healthsc.isEnemy)
                {
                    selfTerminate();
                }

            }
        }

        if (terminateOnPlayer)
        {
            HealthScript healthsc = collider.gameObject.GetComponent<HealthScript>();
            if (healthsc != null)
            {
                if (!healthsc.isEnemy)
                {
                    selfTerminate();
                }

            }
        }

    }

    public void selfTerminate()
    {
        //MoveScript move = GetComponent<MoveScript>();
        //if (move != null)
        //{
        float tempdeg = Mathf.Atan2(lastVelocity.y, lastVelocity.x) * Mathf.Rad2Deg;

        if (effectID == 1)
        {
            SpecialEffectsScript.Instance.playHexagonConeEffect(new Vector3(transform.position.x, transform.position.y, 6), new Vector3(0, 0, tempdeg), transform.localScale);
        }
        else if (effectID == 2)
        {
            SpecialEffectsScript.Instance.playHexagonHollowConeEffect(new Vector3(transform.position.x, transform.position.y, 6), new Vector3(0, 0, tempdeg), transform.localScale);
        }

        foreach (ParticleShooterScript particle in particles)
        {
            float tangle = particle.transform.eulerAngles.z;

            //vary the angles
            if (Random.Range(0, 2) == 0)
            {
                tangle += Random.Range(0, 20);
            }
            else
            {
                tangle -= Random.Range(0, 20);
            }

            Vector2 tempMovement = new Vector2(Mathf.Cos(Mathf.Deg2Rad * tangle), Mathf.Sin(Mathf.Deg2Rad * tangle));
            if (particleID == 1)
            {
                if (Random.Range(0, 100) < 10)
                {
                    SpecialEffectsScript.Instance.spawnNeutral4StarGray(particle.transform.position, new Vector3(.7f, .7f, 1), tempMovement * 12);
                }
                else
                {
                    if (Random.Range(0, 2) == 0)
                    {
                        SpecialEffectsScript.Instance.spawnNeutral4StarRed1(particle.transform.position, new Vector3(.7f, .7f, 1), tempMovement * 12);
                    }
                    else
                    {
                        SpecialEffectsScript.Instance.spawnNeutral4StarRed2(particle.transform.position, new Vector3(.7f, .7f, 1), tempMovement * 12);
                    }
                }
            }
        }
        //}
        //else
        //{
        //    Debug.Log("cant instantiate effect");
        //}
        Destroy(gameObject);
    }
}
