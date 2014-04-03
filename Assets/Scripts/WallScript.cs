using UnityEngine;
using System.Collections;

public class WallScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D collider)
    {/*
        ShotScript shot = collider.gameObject.GetComponent<ShotScript>();
        if(shot!=null)
        {
            Destroy(shot.gameObject);
        }*/

        //Debug.Log("i sense");
    }
}
