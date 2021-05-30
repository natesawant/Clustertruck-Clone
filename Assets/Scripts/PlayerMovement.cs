using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerWalkSpeed, playerSprintSpeed, playerJumpHeight, gravity, playerStrafeSpeed;
    public Rigidbody rb;
    public LayerMask jumpableLayer;
    public GameObject groundCheckObject;
    float jumpDelay;

    //new
    Vector3 truckVector;

    void Update()
    {
        Move();
        Jump();
    }

    void Jump()
    {
        jumpDelay += Time.deltaTime;
        if (GroundCheck() && Input.GetKey(KeyCode.Space) && jumpDelay >= 0.04f) //delay is new
        {
            rb.AddForce(transform.up * playerJumpHeight);
            jumpDelay = 0;
        }
    }

    void Move()
    {
        Vector3 direction = (Input.GetAxis("Vertical") * transform.forward) + (Input.GetAxis("Horizontal") * transform.right);
        if (direction.magnitude >= 1) direction = direction.normalized;


        if (GroundCheck())
        {
            if (Input.GetKey(KeyCode.LeftShift)) rb.velocity = (direction * playerSprintSpeed) + ((rb.velocity.y - (gravity * Time.deltaTime)) * transform.up);
            else rb.velocity = (direction * playerWalkSpeed) + ((rb.velocity.y - (gravity * Time.deltaTime)) * transform.up);
        }
        else rb.AddForce(direction * playerStrafeSpeed); //new
    }


    bool GroundCheck()
    {
        if (Physics.CheckSphere(groundCheckObject.transform.position, 0.4f, jumpableLayer)) return true;
        else return false;
    }


    //new

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Truck")
        {
            transform.position += collision.transform.forward * collision.GetComponent<TruckMovement>().truckSpeed * Time.deltaTime;
            //Debug.Log(collision.GetComponent<TruckMove>().truckSpeed);
        }

        else Debug.Log("No object with tag Truck");
    }
}
