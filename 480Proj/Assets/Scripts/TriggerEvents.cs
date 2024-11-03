using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

/// Trigger events when a player enters a trigger.
public class TriggerEvents : MonoBehaviour
{
    public UnityEvent onTrigger;

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            if (onTrigger != null) {
                onTrigger.Invoke();
            }
        }
    }
}