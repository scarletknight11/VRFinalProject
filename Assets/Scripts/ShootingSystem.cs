using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSystem : MonoBehaviour {

    public float fireRate;
    public int damage;
    public float fieldOfView;
    public bool beam;
    public GameObject projectile;
    public GameObject target;
    public List<GameObject> projectileSpawns;

    List<GameObject> m_lastProjectiles = new List<GameObject>();
    float m_fireTimer = 0.0f;
    
    void Update() {
        if (beam && m_lastProjectiles.Count <= 0) {
            float angle = Quaternion.Angle(transform.rotation, Quaternion.LookRotation(target.transform.position - transform.position));
            
            if (angle < fieldOfView) {
                SpawnProjectile();
            }
        } else if (beam && m_lastProjectiles.Count > 0) {
            float angle = Quaternion.Angle(transform.rotation, Quaternion.LookRotation(target.transform.position - transform.position));

            if (angle > fieldOfView) {
                while (m_lastProjectiles.Count > 0) {
                    Destroy(m_lastProjectiles[0]);
                    m_lastProjectiles.RemoveAt(0);
                }
            }
        } else {
            m_fireTimer += Time.deltaTime;
            if (m_fireTimer >= fireRate) {
                float angle = Quaternion.Angle(transform.rotation, Quaternion.LookRotation(target.transform.position - transform.position));
               
                if (angle < fieldOfView) {
                    SpawnProjectile();

                    m_fireTimer = 0.0f;
                }
            }
        }
    }
 
    void SpawnProjectile() {
        //if projectile not fired
        if(!projectile) {
            return;
        }

        //empties the array list. The length of m_lastProjectiles array will be zero.
        m_lastProjectiles.Clear();

        //for each number of projectile fired/spanwed
        for (int i = 0; i < projectileSpawns.Count; i++)
        {
            //if every number of projectile generated & fired
            if (projectileSpawns[i])
            {
                //clone the # of projectile as gameobject variables, spawn them and move there position
                GameObject proj = Instantiate(projectile, projectileSpawns[i].transform.position, Quaternion.Euler(projectileSpawns[i].transform.forward)) as GameObject;
                //GetComponent Script BaseProjectile.cs and call FireProjectile method and pass it with your parameters
                proj.GetComponent<BaseProjectile>().FireProjectile(projectileSpawns[i], target, damage);

                m_lastProjectiles.Add(proj);
            }
        }
    }
}
