using UnityEngine;
using System.Collections;

public class EnemyShooterScript : MonoBehaviour {

    private WeaponScript weapon;
    private bool shooting = true;
    private Animator animator;

    void Awake()
    {
        weapon = GetComponentInChildren<WeaponScript>();
        animator = GetComponent<Animator>();
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        weapon.shootingRate = .1f;

        animator.SetBool("shooting", shooting);

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Enemy_Shooter_Contracted"))
        {//this.animator.GetCurrentAnimatorStateInfo(0).IsName("YourAnimationName"))
            if (shooting && weapon != null && weapon.enabled && weapon.CanAttack())
            {
                weapon.Attack(true, 0, 5);
                animator.SetTrigger("shoot");
            }
        }
	}
}
