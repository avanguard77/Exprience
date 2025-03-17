using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInPut : MonoBehaviour
{
    private PlayerInputAction PlayerInputAction;


    private void Awake()
    {
        PlayerInputAction = new PlayerInputAction();
        PlayerInputAction.Player.Enable();
    }

    public Vector2 GetMovmentNormalized()
    {
        Vector2 input = PlayerInputAction.Player.Move.ReadValue<Vector2>();
        input.Normalize();
        return input;
    }

    public bool GetMovmentJumped()
    {
        if (PlayerInputAction.Player.Jump.IsPressed())
        {
            return true;
        }

        return false;
    }
}