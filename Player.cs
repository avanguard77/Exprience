using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event EventHandler OnShakinghandAnimation;
    public event EventHandler OnJumpingAnimation;

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private GameInPut gameInPut;

    private bool isWalking;
    private bool isJumping;
    private bool isShakinghand;
    bool istouchingGround = true;
    private float playerRadius = 1f;
    private float playerHight = 3f;
    private Vector3 lastInteraction;
    private Rigidbody playerRb;

    private void Start()
    {
        gameInPut.OnJumping += GameInPutOnOnJumping;
        gameInPut.OnShakinghand += GameInPutOnOnShakinghand;

        playerRb = GetComponent<Rigidbody>();
    }

    private void GameInPutOnOnShakinghand(object sender, EventArgs e)
    {
        OnShakinghandAnimation?.Invoke(this, EventArgs.Empty);
    }

    private void GameInPutOnOnJumping(object sender, EventArgs e)
    {
        OnJumpingAnimation?.Invoke(this, EventArgs.Empty);
    }

    private void Update()
    {
        HandleInteraction();
        HandleMovement();
    }

    private void HandleInteraction()
    {
        Vector2 inputVector2 = gameInPut.GetMovmentNormalized();

        Vector3 movementDir = new Vector3(inputVector2.x, 0f, inputVector2.y);
        if (movementDir != Vector3.zero)
        {
            lastInteraction = movementDir;
        }

        float interactionDistance = 2f;
        if (Physics.Raycast(transform.position, lastInteraction, out RaycastHit hit, interactionDistance))
        {
            Debug.Log(hit.transform);
        }
    }

    private void HandleMovement()
    {
        Vector2 inputVector2 = gameInPut.GetMovmentNormalized();

        Vector3 movementDir = new Vector3(inputVector2.x, 0f, inputVector2.y);

        float movementDistance = moveSpeed * Time.deltaTime;

        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHight,
            playerRadius, movementDir, movementDistance);
        

        if (!canMove)
        {
            
            Vector3 movementDirX = new Vector3(movementDir.x, 0f, 0);
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHight,
                playerRadius, movementDirX, movementDistance);
            if (canMove)
            {
                //move in x Line
                movementDir = movementDirX.normalized;
                Debug.DrawRay(transform.position, movementDir * movementDistance, Color.red);
                // Debug.DrawRay(transform.position, transform.position + Vector3.up * playerHight, Color.red);
            }
            else
            {
                Vector3 movementDirZ = new Vector3(0, 0f, movementDir.z);
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHight,
                    playerRadius, movementDirZ, movementDistance);
                if (canMove)
                {
                    //move in z Line
                    movementDir = movementDirZ.normalized;
                }
            }
        }

        transform.position += movementDir * movementDistance;
        isWalking = movementDir != Vector3.zero;
        isShakinghand = gameInPut.GetMovmentShakedhands();
        isJumping = gameInPut.GetMovmentJumped();

        float jumpMax = 4;


        if (isJumping && istouchingGround)
        {
            float jumpforce = 40 * Time.deltaTime;
            playerRb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
            istouchingGround = false;
        }
        else if (playerRb.position.y > jumpMax)
        {
            playerRb.position = new Vector3(transform.position.x, jumpMax, transform.position.z);
            playerRb.velocity = new Vector3(playerRb.velocity.x, 0, playerRb.velocity.z);
        }
        
        if (Mathf.Abs(transform.position.y) < .7f)
        {
            istouchingGround = true;
        }

        Debug.Log(transform.position);


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
    public bool IsShakinghand()
    {
        return isShakinghand;
    }
}