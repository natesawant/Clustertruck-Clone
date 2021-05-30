using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float truckSpeed, movementVariance, randomRotation;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        truckSpeed = Random.Range(truckSpeed, truckSpeed + movementVariance);
        //rb.drag = Random.Range(0.1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponentInParent<GroundCheckTruck>().isTruckGrounded)
        //if (true)
        {
            transform.position += transform.forward * truckSpeed * Time.deltaTime;
            transform.Rotate(transform.up * Time.deltaTime * Random.Range(-randomRotation, randomRotation));
        }
    }
}
