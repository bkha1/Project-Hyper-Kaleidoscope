using UnityEngine;
using System.Collections;

public class BossSection1Script : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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
