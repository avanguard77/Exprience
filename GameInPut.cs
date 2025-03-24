using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInPut : MonoBehaviour
{
    public event EventHandler OnShakinghand;
    public event EventHandler OnJumping;
    
    public PlayerInputAction PlayerInputAction;
    
    private void Awake()
    {
        
        PlayerInputAction = new PlayerInputAction();
        PlayerInputAction.Player.Enable();
        
        PlayerInputAction.Player.Jump.performed+= JumpOnperformed;
        PlayerInputAction.Player.ShakeHand.performed+= ShakeHandOnperformed;
        
    }

    private void ShakeHandOnperformed(InputAction.CallbackContext obj)
    {
        OnShakinghand?.Invoke(this, EventArgs.Empty);
    }

    private void JumpOnperformed(InputAction.CallbackContext obj)
    {
        OnJumping?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetMovmentNormalized()
    {
        Vector2 input = PlayerInputAction.Player.Move.ReadValue<Vector2>();
        input.Normalize();
        return input;
    }

    public bool GetMovmentJumped()
    {
        if (PlayerInputAction.Player.Jump.IsInProgress())
        {
            return true;
        }

        return false;
    }
    public bool GetMovmentShakedhands()
    {
        if (PlayerInputAction.Player.ShakeHand.IsPressed())
        {
            return true;
        }

        return false;
    }
}