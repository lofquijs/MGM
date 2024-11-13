using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class HandBallThrower : MonoBehaviour
{
    public float throwForce = 10f;
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
        // Check for a specific gesture or button press to throw the ball
        if (IsThrowingGesture(throwActionLeft) || IsThrowingGesture(throwActionRight))
        {
            ThrowBall();
        }
    }

    bool IsThrowingGesture(InputAction action)
    {
        if (action.ReadValue<float>() > 0.5f)
        {
            return true;
        }
        return false;
    }

    void ThrowBall()
    {
        rb.AddForce(transform.forward * throwForce, ForceMode.Impulse);
    }
}
