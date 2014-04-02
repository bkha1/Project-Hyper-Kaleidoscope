using UnityEngine;
using System.Collections;

public class SmoothFollow2D : MonoBehaviour {

    public Transform target;
    public float smoothTime = 0.25f;
    private Transform thisTransform;
    private Vector3 velocity = Vector3.zero;
    //private float velocity;

    Vector3 tempVector;

	// Use this for initialization
	void Start () {
        thisTransform = transform;
        Debug.Log("Initializing SmoothFollow2D");
	}
	
	// Update is called once per frame
	void Update () {
        tempVector = thisTransform.position;
        tempVector.x = Mathf.SmoothDamp(thisTransform.position.x, target.position.x, ref velocity.x, smoothTime);
        tempVector.y = Mathf.SmoothDamp(thisTransform.position.y, target.position.y, ref velocity.y, smoothTime);
	}

    void FixedUpdate()
    {
    }

    void LateUpdate()
    {
        //smoothFollow();
        thisTransform.position = tempVector;
    }

    void smoothFollow()
    {
        Vector3 tempVector = thisTransform.position;
        tempVector.x = Mathf.SmoothDamp(thisTransform.position.x, target.position.x, ref velocity.x, smoothTime);
        tempVector.y = Mathf.SmoothDamp(thisTransform.position.y, target.position.y, ref velocity.y, smoothTime);
        thisTransform.position = tempVector;
    }
}
