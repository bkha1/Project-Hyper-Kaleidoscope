using UnityEngine;
using System.Collections;

public class CheckpointScript : MonoBehaviour {

    private bool isActive = false;
    private RotateScript[] rotates;

    void Awake()
    {
        rotates = GetComponentsInChildren<RotateScript>();
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
