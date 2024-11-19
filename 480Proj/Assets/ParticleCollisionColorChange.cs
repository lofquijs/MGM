using UnityEngine;

public class ParticleCollisionSwitchSphere : MonoBehaviour
{
    public GameObject sphere1;         // Reference to Sphere1
    public int requiredHits = 1;     // Number of particle collisions required
    private int currentHits = 0;      // Counter for particle collisions

    void OnParticleCollision(GameObject other)
    {
        // Check if the colliding object is the particle system
        if (other.CompareTag("WaterParticles")) // Replace "WaterParticles" with your particle system's tag
        {
            // Increment the hit counter
            currentHits++;

            // Check if the required number of hits has been reached
            if (currentHits >= requiredHits)
            {
                // Hide the current sphere
                gameObject.SetActive(false);

                // Show Sphere1
                if (sphere1 != null)
                {
                    sphere1.SetActive(true);
                }

                // Optionally reset the counter or stop further collisions
                // currentHits = 0; // Uncomment to allow repeated behavior
                // this.enabled = false; // Uncomment to stop further collision detection
            }
        }
    }
}
