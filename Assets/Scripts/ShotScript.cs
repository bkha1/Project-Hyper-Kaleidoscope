using UnityEngine;
using System.Collections;

public class ShotScript : MonoBehaviour {

    public int damage = 1;
    public bool isEnemyShot = false;
    //public Transform wallEffectPrefab;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 10);
	}
	
	// Update is called once per frame
	void Update () {
	
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
                SpecialEffectsScript.Instance.playHexagonConeEffect(transform.position, new Vector3(0,0,move.direction), transform.localScale);
            }
            else
            {
                Debug.Log("cant instantiate effect");
            }
            Destroy(gameObject);
        }
    }
}
