using UnityEngine;
using System.Collections;

public class TargetBehavior : MonoBehaviour {

	// explosion when hit?
	public GameObject explosionPrefab;

	// when collided with another gameObject
	void OnCollisionEnter (Collision newCollision) {
		 
 			if (newCollision.gameObject.tag == "Projectile")
			{
				if (explosionPrefab)
				{
					// Instantiate an explosion effect at the gameObjects position and rotation
					Instantiate(explosionPrefab, transform.position, transform.rotation);
				}  
			}
	 			
			// destroy the projectile
			Destroy (newCollision.gameObject);
				
			// destroy self
			Destroy (gameObject);
		}
	}

