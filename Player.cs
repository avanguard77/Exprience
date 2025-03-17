using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private GameInPut gameInPut;

    private bool isWalking;
    private bool isJumping;

    private void Update()
    {
        Vector2 inputVector2 = gameInPut.GetMovmentNormalized();
        
        Vector3 movementDir = new Vector3(inputVector2.x, 0f, inputVector2.y);
        transform.position += movementDir * moveSpeed * Time.deltaTime;
        isWalking = movementDir != Vector3.zero;
        isJumping=gameInPut.GetMovmentJumped();
        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, movementDir, rotateSpeed * Time.deltaTime);
    }

    public bool IsWalking()
    {
        return isWalking;
    }
    public bool IsJumping()
    {
        return isJumping;
    }    
}