using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRespawner : MonoBehaviour
{
    public Vector3 respawnPosition;
    public float respawnThreshold = -10f; // Adjust this value to match the height of your floor

    void Update()
    {
        if (transform.position.y < respawnThreshold)
        {
            RespawnBall();
        }
    }

    void RespawnBall()
    {
        transform.position = respawnPosition;
        transform.rotation = Quaternion.identity; // Reset rotation to avoid rolling
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero; // Reset the velocity
        rb.angularVelocity = Vector3.zero; // Reset the angular velocity
    }
}


