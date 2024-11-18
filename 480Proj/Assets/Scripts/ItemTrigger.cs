using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTrigger : MonoBehaviour
{
    /// <summary>
    /// Triggers an animation on the "effects" GameObject using the specified trigger name.
    /// </summary>
    /// <param name="triggerName">The name of the trigger parameter in the Animator.</param>
    public void UseItemTrigger(string triggerName)
    {
        // Find the "effects" GameObject in the scene
        GameObject effects = GameObject.Find("Effects");

        if (effects != null)
        {
            // Get the Animator component on the "effects" GameObject
            Animator effectsAnimator = effects.GetComponent<Animator>();

            if (effectsAnimator != null)
            {
                // Trigger the animation
                effectsAnimator.SetTrigger(triggerName);
            }
            else
            {
                Debug.LogError("No Animator component found on the 'effects' GameObject.");
            }
        }
        else
        {
            Debug.LogError("'effects' GameObject not found in the scene.");
        }
    }
}
