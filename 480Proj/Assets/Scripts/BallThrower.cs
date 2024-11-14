using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class BallThrower : MonoBehaviour
{
    public float throwForce = 10f;
    private Rigidbody rb;

    // Input Actions
    public InputActionAsset actionAsset;
    private InputAction throwActionLeft;
    private InputAction throwActionRight;

    private XRGrabInteractable grabInteractable;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Find the actions within the asset
        throwActionLeft = actionAsset.FindActionMap("LeftHand").FindAction("Throw");
        throwActionRight = actionAsset.FindActionMap("RightHand").FindAction("Throw");

        // Enable the actions
        throwActionLeft.Enable();
        throwActionRight.Enable();

        // Get the grab interactable component
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.selectEntered.AddListener(OnSelectEntered);
        grabInteractable.selectExited.AddListener(OnSelectExited);
    }

    void OnSelectEntered(SelectEnterEventArgs args)
{
    rb.isKinematic = true; // Make the Rigidbody kinematic while being held
}

void OnSelectExited(SelectExitEventArgs args)
{
    rb.isKinematic = false; // Make the Rigidbody dynamic again when released
    rb.velocity = Vector3.zero;
    rb.angularVelocity = Vector3.zero;

    if (throwActionLeft.triggered || throwActionRight.triggered)
    {
        ThrowBall();
    }
}


    void ThrowBall()
    {
        rb.AddForce(transform.forward * throwForce, ForceMode.Impulse);
    }
}

