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
    private const string isShakingHand = "ISShakingHand";

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        player.OnJumpingAnimation+= PlayerOnOnJumpingAnimation;
    }

    private void PlayerOnOnJumpingAnimation(object sender, EventArgs e)
    {
        animator.SetBool(isJumping, player.IsJumping());
    }

    private void Update()
    {
        animator.SetBool(isWalking, player.IsWalking());
        
        animator.SetBool(isShakingHand, player.IsShakinghand());
    }
}