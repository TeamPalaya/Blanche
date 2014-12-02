using UnityEngine;
using System.Collections;

/// Creating instance of particles from code with no effort
public class SpecialEffectsHelper : MonoBehaviour
{
	/// Singleton
	public static SpecialEffectsHelper Instance;
	public ParticleSystem smokeEffect;
	public ParticleSystem fireEffect;
	void Awake()
	{
		Instance = this;
	}
	public void Explosion(Vector3 position)
	{
		// Smoke on the water
		instantiate(smokeEffect, position);

		// Fire in the sky
		instantiate(fireEffect, position);
	}

	private ParticleSystem instantiate(ParticleSystem
	                                   prefab, Vector3 position)
	{
		ParticleSystem newParticleSystem =
			Instantiate(
				prefab,
				position,
				Quaternion.identity) as ParticleSystem;

		// Make sure it will be destroyed
		Destroy(newParticleSystem.gameObject,
			newParticleSystem.startLifetime);

		return newParticleSystem;

	}
}