using UnityEngine;
using System.Collections;

public class SpecialEffectsScript : MonoBehaviour {

    public static SpecialEffectsScript Instance;

    public Transform hexagonConeEffect;

    public Transform neutral4StarGray;
    public Transform neutral4StarRed1;
    public Transform neutral4StarRed2;

    public Transform playerRagdoll;
    public Transform playerRespawnLight;

	// Use this for initialization
	void Awake() {
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of SpecialEffectsScript!");
        }
	
        Instance=this;
	}

    public void playHexagonConeEffect(Vector3 position, Vector3 euler, Vector3 scale)
    {
        var effectTransform = Instantiate(hexagonConeEffect) as Transform;
        effectTransform.position = position;
        effectTransform.eulerAngles = euler;
        //effectTransform.rotation = rotation;
        effectTransform.localScale = scale;
        Destroy(effectTransform.gameObject, 5f);
    }

    public void spawnNeutral4StarGray(Vector3 position, Vector3 scale, Vector2 force)
    {
        var effectTransform = Instantiate(neutral4StarGray) as Transform;
        effectTransform.position = position;
        //effectTransform.eulerAngles = euler;
        effectTransform.localScale = scale;
        //effectTransform.gameObject.rigidbody2D.AddForceAtPosition(new Vector2(1, -1), position);
        effectTransform.gameObject.rigidbody2D.AddForce(force);
        Destroy(effectTransform.gameObject, 10);
    }

    public void spawnNeutral4StarRed1(Vector3 position, Vector3 scale, Vector2 force)
    {
        var effectTransform = Instantiate(neutral4StarRed1) as Transform;
        effectTransform.position = position;
        effectTransform.localScale = scale;
        effectTransform.gameObject.rigidbody2D.AddForce(force);
        Destroy(effectTransform.gameObject, 10);
    }

    public void spawnNeutral4StarRed2(Vector3 position, Vector3 scale, Vector2 force)
    {
        var effectTransform = Instantiate(neutral4StarRed2) as Transform;
        effectTransform.position = position;
        effectTransform.localScale = scale;
        effectTransform.gameObject.rigidbody2D.AddForce(force);
        Destroy(effectTransform.gameObject, 10);
    }

    public void spawnPlayerRagdoll(Vector3 position, Vector3 scale, Vector3 euler, Vector2 force)
    {
        var effectTransform = Instantiate(playerRagdoll) as Transform;
        effectTransform.position = position;
        effectTransform.localScale = scale;
        effectTransform.eulerAngles = euler;
        //effectTransform.gameObject.rigidbody2D.AddForce(force);

        Rigidbody2D[] rigids = effectTransform.GetComponentsInChildren<Rigidbody2D>();
        foreach (Rigidbody2D r in rigids)
        {
            r.AddForce(force);
        }
    }

    public void spawnPlayerRespawnLight(Vector3 position, Vector3 scale)
    {
        var effectTransform = Instantiate(playerRespawnLight) as Transform;
        effectTransform.position = position;
        effectTransform.localScale = scale;
    }


    /*
    private ParticleSystem instantiate(ParticleSystem prefab, Vector3 position)
    {
        ParticleSystem newParticleSystem = Instantiate(
          prefab,
          position,
          Quaternion.identity
        ) as ParticleSystem;

        // Make sure it will be destroyed
        Destroy(
          newParticleSystem.gameObject,
          newParticleSystem.startLifetime
        );

        return newParticleSystem;
    }*/
}
