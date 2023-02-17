using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_FPSCamera : MonoBehaviour
{
    [SerializeField] private Transform rootTransform;
    [SerializeField] private float mouseSensitivity;

    private void OnEnable()
    {
        P_PlayerMain.mouseDelta += RotateCamera;
    }

    private void OnDisable()
    {
        P_PlayerMain.mouseDelta -= RotateCamera;
    }

    private void RotateCamera(Vector2 dir)
    {
        rootTransform.rotation *= Quaternion.Euler(0, dir.x * mouseSensitivity, 0);
        transform.rotation *= Quaternion.Euler(-dir.y * mouseSensitivity, 0, 0);
    }
}
