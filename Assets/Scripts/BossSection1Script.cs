using UnityEngine;
using System.Collections;

public class BossSection1Script : MonoBehaviour {

    private WeaponScript[] weapons;

    //TODO: make boss in mutual layer when it is shooting out hollows, then change it to not mutual when it is in saw mode

    void Awake()
    {
        weapons = GetComponentsInChildren<WeaponScript>();
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        foreach (WeaponScript wep in weapons)
        {
            if (wep != null && wep.enabled && wep.CanAttack())
            {
                wep.Attack(true, 0, 2.5f);
            }
        }
	
	}

    void OnCollisionEnter2D(Collision2D collider)
    {
        PlayerScript pl = collider.gameObject.GetComponent<PlayerScript>();
        if (pl != null)
        {
            //Debug.Log("yo i got touched");
        }
    }
}
