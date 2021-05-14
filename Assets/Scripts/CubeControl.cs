using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeControl : MonoBehaviour {
    public float speed = 10f;
    public float jumpSpeed = 10f;
    public float distToGround = 0.5f;
    public GameObject vitals;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();
        vitals.SetActive(true);
    }

    // Update is called once per frame
    void FixedUpdate() {

        Debug.Log (isGrounded());

        if (Input.GetKey(KeyCode.Space)) {
            //add force to y axis to make object float upward little bit
            rb.AddForce(0, 11f, 0);
        }
        if (Input.GetKey(KeyCode.Z))
        {
            //add force to y axis to make object float upward little bit
            vitals.SetActive(false);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            //add force to y axis to make object float upward little bit
            vitals.SetActive(true);
        }

        
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 movement = new Vector3(vertical * speed * Time.deltaTime, 0, horizontal * speed * Time.deltaTime);
        rb.MovePosition(transform.position + movement);
    }

    bool isGrounded () {
        return Physics.Raycast(transform.position, Vector3.down, distToGround);
    }
}
