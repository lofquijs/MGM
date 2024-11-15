using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class PointAndMove : MonoBehaviour
{
    public float movementSpeed = 1.0f;
    public XRNode handNode = XRNode.RightHand; // Use either hand
    public Transform playerTransform; // Reference to the player's transform
    public Transform cameraTransform; // Reference to the camera's transform
    public float forwardThreshold = 0.8f; // Adjust this value to control the forward direction sensitivity

    private InputDevice handDevice;
    private bool isPointing = false;

    void Start()
    {
        handDevice = InputDevices.GetDeviceAtXRNode(handNode);
        Debug.Log("Hand Device Initialized: " + handDevice.name);
    }

    void Update()
    {
        Vector3 handPosition;
        Quaternion handRotation;

        if (handDevice.TryGetFeatureValue(CommonUsages.devicePosition, out handPosition) &&
            handDevice.TryGetFeatureValue(CommonUsages.deviceRotation, out handRotation))
        {
            Debug.Log("Hand Position: " + handPosition + " Hand Rotation: " + handRotation);

            // Calculate the forward direction of the hand
            Vector3 handForwardDirection = handRotation * Vector3.forward;

            // Ensure the hand is pointing forward and within a certain angle range
            float handDotProduct = Vector3.Dot(cameraTransform.forward, handForwardDirection);
            isPointing = handDotProduct > forwardThreshold;

            Debug.Log("Hand Dot Product: " + handDotProduct + " Is Pointing Forward: " + isPointing);

            // Move the player if the hand is pointing forward and the camera is also looking forward
            if (isPointing)
            {
                Vector3 direction = cameraTransform.forward; // Move in the camera's forward direction
                playerTransform.Translate(direction * movementSpeed * Time.deltaTime);
                Debug.Log("Moving in Direction: " + direction);
            }
        }
    }
}




