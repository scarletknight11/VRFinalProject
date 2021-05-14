using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroEnemy : MonoBehaviour {

    public GameObject explosionPrefab;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Projectile"))
        {
            if (explosionPrefab)
            {
                // Instantiate an explosion effect at the gameObjects position and rotation
                Instantiate(explosionPrefab, transform.position, transform.rotation);
            }
            // destroy the projectile
            Destroy(collision.gameObject);

            // destroy self
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Projectile"))
        {
            if (explosionPrefab)
            {
                // Instantiate an explosion effect at the gameObjects position and rotation
                Instantiate(explosionPrefab, transform.position, transform.rotation);
            }
            // destroy the projectile
            Destroy(other.gameObject);

            // destroy self
            Destroy(gameObject);
            //enemy.SetActive(false);
        }
    }
}
