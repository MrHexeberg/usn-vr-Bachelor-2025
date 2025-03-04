using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionscript : MonoBehaviour

{
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Når objektet treffer noe
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Kollisjon med: " + collision.gameObject.name);
        rb.velocity = Vector3.zero;  // Stopper all bevegelse
        rb.angularVelocity = Vector3.zero;  // Stopper rotasjon
    }
}

// Update is called once per frame


