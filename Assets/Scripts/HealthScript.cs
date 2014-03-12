using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {

    public int hp = 1;
    public bool isEnemy = true;

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
        /*
        // Is this a shot?
        ShotScript shot = collider.gameObject.GetComponent<ShotScript>();
        if (shot != null)
        {
            // Avoid friendly fire
            if (shot.isEnemyShot != isEnemy)
            {
                hp -= shot.damage;

                Destroy(shot.gameObject);

                if (hp <= 0)
                {
                    SpecialEffectsHelper.Instance.Explosion(transform.position);
                    SoundEffectsHelper.Instance.MakeExplosionSound();
                    // Dead!
                    Destroy(gameObject);
                }
            }
        }*/

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
    }
}
