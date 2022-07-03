using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private InputActionReference horizontalLook;
    [SerializeField] private InputActionReference verticalLook;

    [SerializeField] private float lookSpeed = 1f;
    [SerializeField] private Transform cameraTransform;

    private float pitch;
    private float yaw;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        horizontalLook.action.performed += HandleHorizontalLookChange;
        verticalLook.action.performed += HandleVerticalLookChange;
    }

    private void HandleHorizontalLookChange(InputAction.CallbackContext obj)
    {
        yaw += obj.ReadValue<float>();
        transform.localRotation = Quaternion.AngleAxis(yaw * lookSpeed, Vector3.up);
    }

    private void HandleVerticalLookChange(InputAction.CallbackContext obj)
    {
        pitch += obj.ReadValue<float>();
        cameraTransform.localRotation = Quaternion.AngleAxis(pitch * lookSpeed, Vector3.right);

    }
}