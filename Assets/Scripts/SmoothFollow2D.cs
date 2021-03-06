﻿using UnityEngine;
using System.Collections;

public class SmoothFollow2D : MonoBehaviour {

    public Transform target;
    public float smoothTime = 0.25f;
    public bool isFollowing = true;

    private Transform thisTransform;
    private Vector3 velocity = Vector3.zero;

    private bool focusing = false;

    Vector3 tempVector;

    void Awake()
    {
        transform.position = new Vector3(target.position.x,target.position.y,transform.position.z);
    }

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
        if (!focusing)
        {
            if (isFollowing)
            {
                thisTransform.position = tempVector;
            }
        }
        else
        {
            focusing = false;
            //isFollowing = true;
        }
    }

    void smoothFollow()
    {
        Vector3 tempVector = thisTransform.position;
        tempVector.x = Mathf.SmoothDamp(thisTransform.position.x, target.position.x, ref velocity.x, smoothTime);
        tempVector.y = Mathf.SmoothDamp(thisTransform.position.y, target.position.y, ref velocity.y, smoothTime);
        thisTransform.position = tempVector;
    }

    
    public void focusCamera()
    {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
        focusing = true;
        //isFollowing = false;
    }

    
}
