using UnityEngine;
using System.Collections;

public class ObjectFadeAwayScript : MonoBehaviour {

    public float fadeCooldown = 3;

    private float maxTime;
    private SpriteRenderer[] sprites;
    private TrailRenderer[] trails;

    void Awake()
    {
        sprites = GetComponentsInChildren<SpriteRenderer>();
        trails = GetComponentsInChildren<TrailRenderer>();
    }

	// Use this for initialization
	void Start () {
        maxTime = fadeCooldown;

        
        //disables all trails
        foreach (TrailRenderer trail in trails)
        {
            trail.enabled = false;
        }
         
	}
	
	// Update is called once per frame
	void Update () {

        if (fadeCooldown > 0)
        {
            fadeCooldown -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }

        foreach (SpriteRenderer sprite in sprites)
        {
            Color tempcolor = sprite.color;
            tempcolor.a = fadeCooldown / maxTime;
            sprite.color = tempcolor;//new Color(fadeCooldown / maxTime);
        }

        //Attempt to make trails fade out; DOESNT WORK
        /*foreach (TrailRenderer trail in trails)
        {
            Material tempMat = trail.material;

            for(int i=0;i<5;i++)
            {
                Color tempColor = tempMat.GetColor(i);
                tempColor.a = fadeCooldown / maxTime;
                tempMat.SetColor(i, tempColor);
            }

            trail.material = tempMat;
            
        }*/
	
	}
}
