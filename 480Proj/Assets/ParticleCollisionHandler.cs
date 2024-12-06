using UnityEngine;
using System.Collections;

public class ParticleCollisionHandler : MonoBehaviour
{
    private Renderer sphereRenderer;

    void Start()
    {
        // Get the Renderer component of the sphere
        sphereRenderer = GetComponent<Renderer>();

        if (sphereRenderer == null)
        {
            Debug.LogError("Renderer component not found on the sphere.");
        }
    }

    void OnParticleCollision(GameObject other)
    {
       
        // Change the color of the sphere to green on collision
        if (other.CompareTag("water")) // Ensure the collision is with a particle system
        {
             Debug.Log("Particle collided with: " + gameObject.name);
            if (sphereRenderer != null)
            {
                sphereRenderer.material.color = Color.green;
            }
        }
    }
    IEnumerator FlashColor()
{
    sphereRenderer.material.color = Color.green;
    yield return new WaitForSeconds(0.5f);
    sphereRenderer.material.color = Color.white; // Reset to original color
}

}
