using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheckTruck : MonoBehaviour
{
    public bool isTruckGrounded = true;

    private void OnTriggerStay(Collider collision)
    {
        Debug.Log(collision.name);
        if (collision.tag == "Ground")
        {
            isTruckGrounded = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        isTruckGrounded = false;
    }

}
