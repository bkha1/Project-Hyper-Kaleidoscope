using UnityEngine;
using System.Collections;

public class ObjectFadeAwayScript : MonoBehaviour {

    public float fadeCooldown = 3;

    private float maxTime;
    private SpriteRenderer[] sprites;

    void Awake()
    {
        sprites = GetComponentsInChildren<SpriteRenderer>();
    }

	// Use this for initialization
	void Start () {
        maxTime = fadeCooldown;
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
	
	}
}
