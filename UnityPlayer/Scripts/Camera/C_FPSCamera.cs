using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_FPSCamera : MonoBehaviour
{
    private bool isPaused;
    [SerializeField] private Transform rootTransform;
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _playerHand;
    [SerializeField] private float raycastDistance = 5f;
    private int interactableLayer = 1 << 9;

    private I_Interact _interactable;
    private I_Interact _currentLiftable;

    private void OnEnable()
    {
        P_PlayerMain.mouseLeftClick += ClickOnInteractableItems;
        P_PlayerMain.playerPause += OnPlaysePause;
        P_PlayerMain.mouseDelta += RotateCamera;
    }

    private void OnDisable()
    {
        P_PlayerMain.mouseLeftClick -= ClickOnInteractableItems;
        P_PlayerMain.playerPause -= OnPlaysePause;
        P_PlayerMain.mouseDelta -= RotateCamera;
    }

    private void OnPlaysePause(bool pause)
    {
        if(pause)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        isPaused = pause;
    }

    private void RotateCamera(Vector2 dir)
    {
        if (isPaused) return;
        rootTransform.rotation *= Quaternion.Euler(0, dir.x * mouseSensitivity, 0);
        transform.rotation *= Quaternion.Euler(-dir.y * mouseSensitivity, 0, 0);
    }

    private void FixedUpdate()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, raycastDistance, interactableLayer))
        {
            if(hit.collider.gameObject.TryGetComponent<I_Interact>(out I_Interact interactable))
            {
                _interactable = interactable;
                _interactable.OnHit(gameObject);
            }
        }
        else if (_interactable != null)
        {
            _interactable.OnLeave();
            _interactable = null;
        }
    }

    private void ClickOnInteractableItems(bool click)
    {
        if(click)
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, raycastDistance, interactableLayer))
            {
                if (hit.collider.gameObject.TryGetComponent<I_Interact>(out I_Interact interactable))
                {
                    _currentLiftable = interactable;
                    _currentLiftable.OnClick(_playerHand.gameObject);
                }
            }
        }
        else
        {
            if (_currentLiftable != null)
            {
                _currentLiftable.OnRelease(gameObject);
                _currentLiftable = null;
            }
        }
    }

    public void RemoveInterface()
    {
        _currentLiftable = null;
        _interactable= null;
    }
}
