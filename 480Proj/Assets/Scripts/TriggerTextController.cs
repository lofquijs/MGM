using UnityEngine;

public class TriggerTextController : MonoBehaviour
{
    [SerializeField] private GameObject textObject; // Assign your TextMeshPro object here in the Inspector.

    private void Start()
    {
        if (textObject != null)
            textObject.SetActive(false); // Ensure it's initially hidden.
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is the player or XR Rig.
        if (other.CompareTag("Player")) // Adjust the tag to match your XR Rig or player object.
        {
            if (textObject != null)
                textObject.SetActive(true); // Show the text when the player enters.
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (textObject != null)
                textObject.SetActive(false); // Hide the text when the player exits.
        }
    }
}
