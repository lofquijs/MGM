using UnityEngine;
using UnityEngine.InputSystem; // For the New Input System

public class AnimationTrigger : MonoBehaviour
{
    [SerializeField] private Animator animator; // Reference to the Animator component
    [SerializeField] private InputAction triggerAction; // Input Action for triggering the animation

    void OnEnable()
    {
        // Enable the input action
        triggerAction.Enable();
    }

    void OnDisable()
    {
        // Disable the input action to avoid memory leaks
        triggerAction.Disable();
    }

    void Update()
    {
        // Check if the action was performed
        if (triggerAction.triggered)
        {
            TriggerShotAnimation();
        }
    }

    public void TriggerShotAnimation()
    {
        if (animator != null)
        {
            animator.SetTrigger("Shot"); // Set the "Shot" trigger in the Animator
        }
        else
        {
            Debug.LogWarning("Animator not assigned!");
        }
    }
}
