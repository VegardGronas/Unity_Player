using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_ThirdBoom : MonoBehaviour
{
    private bool isPaused;
    [SerializeField] private Transform _verticalRotator;
    [SerializeField] private float _mouseSensitivity = 1f;
    [SerializeField] private P_PlayerMove _playerMove;
    [SerializeField] private Transform _camera;
    [SerializeField] private Transform _cameraParent;

    private void OnEnable()
    {
        P_PlayerMain.playerPause += OnPlaysePause;
        P_PlayerMain.mouseDelta += RotateCamera;   
    }
    private void OnDisable()
    {
        P_PlayerMain.playerPause -= OnPlaysePause;
        P_PlayerMain.mouseDelta -= RotateCamera;
    }

    private void Start()
    {
        _playerMove.ChangeTransformForMove(transform);
    }

    private void OnPlaysePause(bool pause)
    {
        if (pause)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        isPaused = pause;
    }

    private void RotateCamera(Vector2 mouseDelta)
    {
        transform.rotation *= Quaternion.Euler(0, mouseDelta.x * _mouseSensitivity, 0);
        _verticalRotator.rotation *= Quaternion.Euler(mouseDelta.y * _mouseSensitivity, 0, 0);
    }

    private void FixedUpdate()
    {
        RaycastHit hit;

        Vector3 direciton = (transform.position - _cameraParent.position).normalized;
        float distance = Vector3.Distance(transform.position, _cameraParent.position);

        if(Physics.Raycast(transform.position, -direciton, out hit, distance))
        {
            _camera.position = hit.point;
        }
        else
        {
            _camera.position = _cameraParent.position;
        }
    }
}