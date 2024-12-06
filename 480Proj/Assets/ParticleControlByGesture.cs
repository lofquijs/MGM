using UnityEngine;

public class ParticleControlByGesture : MonoBehaviour
{
    // Reference to the particle system
    private ParticleSystem particleSystem;
    private ParticleSystem.EmissionModule emissionModule;

    // A placeholder to simulate detecting WaterGesture
    public bool isWaterGestureDetected = false;

    // Emission rates
    public float emissionRateOverTime = 30f; // Adjust as needed
    public float emissionRateOverDistance = 0f; // Set non-zero if using distance-based emission

    void Start()
    {
        // Get the particle system and its emission module
        particleSystem = GetComponent<ParticleSystem>();
        emissionModule = particleSystem.emission;

        // Ensure the emission is off initially
        emissionModule.rateOverTime = 0f;
        emissionModule.rateOverDistance = 0f;
    }

    void Update()
    {
        // Check for the gesture (replace this logic with your actual gesture detection system)
        if (isWaterGestureDetected)
        {
            // If the gesture is detected, enable particle emission
            if (emissionModule.rateOverTime.constant == 0f)
            {
                emissionModule.rateOverTime = emissionRateOverTime;
                emissionModule.rateOverDistance = emissionRateOverDistance;
            }
        }
        else
        {
            // If the gesture is not detected, disable particle emission
            if (emissionModule.rateOverTime.constant != 0f)
            {
                emissionModule.rateOverTime = 0f;
                emissionModule.rateOverDistance = 0f;
            }
        }
    }

    // Simulate gesture detection toggle (for testing)
    private void OnGUI()
    {
        if (GUILayout.Button("Toggle Water Gesture"))
        {
            isWaterGestureDetected = !isWaterGestureDetected;
        }
    }
}
