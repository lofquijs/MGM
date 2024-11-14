using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRespawner : MonoBehaviour
{
    public Vector3 respawnPosition;
    public float respawnThreshold = -10f; // Adjust this value to match the height of your floor or ground

    void Update()
    {
        if (transform.position.y < respawnThreshold)
        {
            RespawnArrow();
        }
    }

    void RespawnArrow()
    {
        // Reset position and orientation
        transform.position = respawnPosition;
        transform.rotation = Quaternion.identity; // Reset rotation to avoid odd angles

        // Reset velocities to ensure the arrow doesn't keep moving
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero; // Reset the velocity
        rb.angularVelocity = Vector3.zero; // Reset the angular velocity
    }
}

