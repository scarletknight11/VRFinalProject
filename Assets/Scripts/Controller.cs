using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    public List<GameObject> springs;
    public Rigidbody rb;
    public GameObject prop;
    public GameObject CM;

    // Start is called before the first frame update
    void Start()
    {
        //get position relative to transform and rotation of object center of mass
        rb.centerOfMass = CM.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        //applies torque and force on the object.
        rb.AddForceAtPosition(Time.deltaTime * transform.TransformDirection(Vector3.forward) * Input.GetAxis("Vertical") * 400f, prop.transform.position);
        //applies adding the torque to the x-axis and keeping object floating up contiouesly stable
        rb.AddTorque(Time.deltaTime * transform.TransformDirection(Vector3.up) * Input.GetAxis("Horizontal") * 300f);
        foreach (GameObject spring in springs) { 
        //The Rigidbody of the collider that was hit
        RaycastHit hit; 
            if (Physics.Raycast(spring.transform.position, transform.TransformDirection(Vector3.down), out hit, 3f))
            {
                rb.AddForceAtPosition(Time.deltaTime * transform.TransformDirection(Vector3.up) * Mathf.Pow(3f - hit.distance, 2)/3f * 250f, spring.transform.position);
            }
            Debug.Log(hit.distance);
        }
        rb.AddForce(-Time.deltaTime * transform.TransformVector(Vector3.right) * transform.InverseTransformVector(rb.velocity).x * 5f);

    }
}
