using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Player player;
    private Animator animator;
    private const string isWalking = "IsWlking";
    private const string isJumping = "IsJumping";

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetBool(isWalking, player.IsWalking());
        animator.SetBool(isJumping, player.IsJumping());
    }
}