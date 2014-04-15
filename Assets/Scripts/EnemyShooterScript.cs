using UnityEngine;
using System.Collections;

public class EnemyShooterScript : MonoBehaviour {

    private WeaponScript weapon;

    void Awake()
    {
        weapon = GetComponentInChildren<WeaponScript>();
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (weapon != null && weapon.enabled && weapon.CanAttack())
        {
            weapon.Attack(true,0,5);
        }
	}
}
