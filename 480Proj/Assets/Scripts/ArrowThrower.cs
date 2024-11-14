using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ArrowThrower : MonoBehaviour
{
    public float throwForce = 10f; // Adjust this value to change the throwing force
    private Rigidbody rb;

    // Input Actions
    public InputActionAsset actionAsset;
    private InputAction throwActionLeft;
    private InputAction throwActionRight;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Find the actions within the asset
        throwActionLeft = actionAsset.FindActionMap("LeftHand").FindAction("Throw");
        throwActionRight = actionAsset.FindActionMap("RightHand").FindAction("Throw");

        // Enable the actions
        throwActionLeft.Enable();
        throwActionRight.Enable();
    }

    void Update()
    {
        if (throwActionLeft.triggered || throwActionRight.triggered)
        {
            ThrowArrow();
        }
    }

    void ThrowArrow()
    {
        rb.velocity = Vector3.zero; // Reset velocity to ensure consistent throws
        rb.angularVelocity = Vector3.zero; // Reset angular velocity
        rb.AddForce(transform.forward * throwForce, ForceMode.Impulse);
    }
}

