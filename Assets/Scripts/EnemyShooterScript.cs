using UnityEngine;
using System.Collections;

public class EnemyShooterScript : MonoBehaviour {

    private WeaponScript weapon;
    private bool shooting = true;
    private Animator animator;

    public float shootCooldown = 1f;
    private float shootCooldownTimer;
    public int numOfContractions = 3;//number of contraction shot animations before a cooldown
    private int contractionCounter;

    public float wakeupTime = 0f;
    public float bulletSpeed = 5;
    //public bool mutualBullets = false;

    //private float tempTime = 0;

    void Awake()
    {
        weapon = GetComponentInChildren<WeaponScript>();
        animator = GetComponent<Animator>();
    }

	// Use this for initialization
	void Start () {
        shootCooldownTimer = shootCooldown;
        contractionCounter = numOfContractions;
	}
	
	// Update is called once per frame
	void Update () {
        //weapon.shootingRate = .1f;//.3 rate is the perfect point, less and itll shoot more per animation
        //tempTime += Time.deltaTime;
        if (wakeupTime <= 0)
        {
            if (contractionCounter > 0)
            {
                shooting = true;
            }
            else
            {
                shooting = false;
                //Debug.Log(tempTime);
                //tempTime = 0;
                //IT TAKES AROUND .65 seconds to do one shot
            }

            if (!shooting)
            {
                shootCooldownTimer -= Time.deltaTime;
                if (shootCooldownTimer <= 0)
                {
                    contractionCounter = numOfContractions;
                    shootCooldownTimer = shootCooldown;
                }
            }

            /*if(animator.GetCurrentAnimatorStateInfo(0).IsName("Enemy_Shooter_Idle"))
            {
                Debug.Log(tempTime);
            }*/

            animator.SetBool("shooting", shooting);

            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Enemy_Shooter_Contracted"))
            {
                if (shooting && weapon != null && weapon.enabled && weapon.CanAttack())
                {
                    weapon.Attack(true, 0, bulletSpeed);
                    animator.SetTrigger("shoot");
                    contractionCounter--;
                }
            }
        }
        else
        {
            wakeupTime -= Time.deltaTime;
        }
	}
}
