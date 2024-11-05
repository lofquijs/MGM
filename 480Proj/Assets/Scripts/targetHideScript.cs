using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideOnHit : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the object that collided with this object has the tag "dart"
        if (collision.gameObject.CompareTag("dart"))
        {
            // Hide the target object
            gameObject.SetActive(false);
        }
    }
}
