using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class P_PlayerMain : MonoBehaviour
{
    private Vector2 _mouseDelta;
    private Vector2 _moveDirection;

    public static event Action<Vector2> mouseDelta;
    public static event Action<Vector2> moveDirection;

    public static event Action<bool> mouseLeftClick;

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
}