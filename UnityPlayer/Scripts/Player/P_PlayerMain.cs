using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class P_PlayerMain : MonoBehaviour
{
    [SerializeField] private GameObject ui_InGameOverlay;
    [SerializeField] private GameObject ui_InGamePauseMenu;

    public static event Action<Vector2> mouseDelta;
    public static event Action<Vector2> moveDirection;

    public static event Action<bool> mouseLeftClick;
    public static event Action<bool> playerPause;
    public static event Action<bool> playerJump;

    private void Start()
    {
        ui_InGamePauseMenu.SetActive(false);
        ui_InGameOverlay.SetActive(true);
    }

    //INPUT
    public void ActionMove(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            moveDirection?.Invoke(context.ReadValue<Vector2>());
        }
        else
        {
            moveDirection?.Invoke(Vector2.zero);
        }
    }

    public void ActionMouseDelta(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            mouseDelta?.Invoke(context.ReadValue<Vector2>());
        }
    }

    public void ActionLeftClick(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            mouseLeftClick?.Invoke(true);
        }
        else
        {
            mouseLeftClick?.Invoke(false);
        }
    }

    public void ActionPause(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            UpdateUIElemts();
            playerPause?.Invoke(ui_InGamePauseMenu.activeInHierarchy);
        }
    }

    public void ActionJump(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            playerJump?.Invoke(true);
        }
    }

    private void UpdateUIElemts()
    {
        ui_InGamePauseMenu.SetActive(!ui_InGamePauseMenu.activeInHierarchy);
        ui_InGameOverlay.SetActive(!ui_InGamePauseMenu.activeInHierarchy);
    }
}