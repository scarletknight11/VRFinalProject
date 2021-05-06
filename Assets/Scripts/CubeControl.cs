using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeControl : MonoBehaviour {
    public float speed = 10f;
    public float jumpSpeed = 10f;
    public float distToGround = 0.5f;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void FixedUpdate() {

        Debug.Log (isGrounded());

        if (Input.GetKey(KeyCode.Space)) {
            //add force to y axis to make object float upward little bit
            rb.AddForce(0, 11f, 0);
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal * speed * Time.deltaTime, 0, vertical * speed * Time.deltaTime);
        rb.MovePosition(transform.position + movement);
    }

    bool isGrounded () {
        return Physics.Raycast(transform.position, Vector3.down, distToGround);
    }
}
