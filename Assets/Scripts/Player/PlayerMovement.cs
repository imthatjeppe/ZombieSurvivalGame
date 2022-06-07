using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float jumpBoost;
    public float speed;
    public float runSpeed;

    private float startSpeed;
    Rigidbody rb;
    bool grounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        grounded = true;
        startSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();
    }


    void Movement()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontal, 0, vertical) * (speed * Time.deltaTime));

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = runSpeed;
        }
        else
        {
            speed = startSpeed;
        }
        
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.AddForce(Vector3.up * jumpBoost, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        grounded = false;
    }

    private void OnTriggerExit(Collider other)
    {
        grounded = true;
    }

}

