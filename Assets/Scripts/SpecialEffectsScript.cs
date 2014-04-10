using UnityEngine;
using System.Collections;

public class SpecialEffectsScript : MonoBehaviour {

    public static SpecialEffectsScript Instance;

    public Transform hexagonConeEffect;

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
        Destroy(effectTransform.gameObject, 2f);
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
