using UnityEngine;
using System.Collections;

public class RotateScript : MonoBehaviour {

    public int speed = -100;
    public bool isRigidbody = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (isRigidbody == false)
        {
            transform.Rotate(0, 0, speed * Time.deltaTime);
        }
	}

    void FixedUpdate()
    {
        if (isRigidbody)
        {
            transform.Rotate(0, 0, speed * Time.deltaTime);
        }
    }
}
