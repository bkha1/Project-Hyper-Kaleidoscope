using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {

    public int hp = 1;
    public bool isEnemy = true;
    public bool isInvincible = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        
        HealthScript enemy = collider.gameObject.GetComponent<HealthScript>();
        if (enemy != null)
        {
            if (enemy.isEnemy && !isEnemy)
            {
                //hurt player
                hp--;
                Debug.Log("hp: " + hp);
            }
        }

        ShotScript shot = collider.gameObject.GetComponent<ShotScript>();
        if (shot != null)
        {
            if (shot.isEnemyShot != isEnemy)
            {
                hp -= shot.damage;
                Debug.Log("hp: " + hp);
                Destroy(shot.gameObject);
            }
        }
    }
}
