using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamProjectile : BaseProjectile {
    public float beamLength = 10.0f;
    GameObject m_launcher;

    // Update is called once per frame
    void Update() {
        //if launcher for projectile
        if (m_launcher) {
            //render line at start position
            GetComponent<LineRenderer>().SetPosition(0, m_launcher.transform.position);
            //increase line blast as yoy push gameobject bullet
            GetComponent<LineRenderer>().SetPosition(1, m_launcher.transform.position + (m_launcher.transform.forward * beamLength));

        }
    }

    //fire projectile, launch the projectile prefab and set it to target and compute damage
    public override void FireProjectile(GameObject launcher, GameObject target, int damage) {
        if (launcher) { 
            m_launcher = launcher;
        }
    }
}
