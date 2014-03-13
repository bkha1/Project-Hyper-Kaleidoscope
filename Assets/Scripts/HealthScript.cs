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
        /*
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

        WallScript wall = collider.gameObject.GetComponent<WallScript>();
        if (wall != null)
        {
            if (!isEnemy)
            {
                //Debug.Log("HI! I AM A WALL! NICE TO MEET YOU!");
            }
        }
         * */
    }
}
