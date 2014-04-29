using UnityEngine;
using System.Collections;

public class CheckpointScript : MonoBehaviour {

    public bool isActive = false;
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

        if (isActive == false)
        {
            foreach (RotateScript rot in rotates)
            {
                if (rot.gameObject.transform.eulerAngles.z != 0)
                {
                    if ((rot.speed < 0 && rot.gameObject.transform.eulerAngles.z < 180) || (rot.speed > 0 && rot.gameObject.transform.eulerAngles.z > 180))//ensures that it rotates the correct way
                    {
                        rot.enabled = false;
                        float angle = Mathf.MoveTowardsAngle(rot.gameObject.transform.eulerAngles.z, 0f, Mathf.Abs(rot.speed) * Time.deltaTime);
                        rot.gameObject.transform.eulerAngles = new Vector3(0, 0, angle);
                    }
                }

                /*float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.y, target, speed * Time.deltaTime);
                transform.eulerAngles = new Vector3(0, angle, 0);/*
                /*if (rot.gameObject.transform.eulerAngles.z <= 5 || rot.gameObject.transform.eulerAngles.z >= 355)
                {
                    rot.enabled = false;
                }*/
            }
        }
        else
        {
            foreach (RotateScript rot in rotates)
            {
                rot.enabled = true;
            }
        }
	}
}
