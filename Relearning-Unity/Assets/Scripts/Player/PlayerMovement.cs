using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private LadderController ladderController;
    private PlayerController playerController;
    private Rigidbody2D rigidBody;
    private CapsuleCollider2D boxCollider;
    private SpriteRenderer spriteRenderer;
    public LayerMask groundLayers;
    public float movementSpeed = 10;
    public float jumpPower = 7;

    private enum MoveDirection { LEFT, RIGHT, UP, NONE }
    private enum LadderDirection { UP, DOWN, NONE }

    private LadderDirection ladderDirection;
    private MoveDirection hMoveDirection;
    private MoveDirection vMoveDirection;


    private void Start()
    {
        groundLayers = LayerMask.GetMask("Ground") + LayerMask.GetMask("Platform") + LayerMask.GetMask("FallingPlatform");

        playerController = GetComponent<PlayerController>();
        ladderController = GetComponent<LadderController>();
        rigidBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<CapsuleCollider2D>();
        ladderDirection = LadderDirection.NONE;
        hMoveDirection = MoveDirection.NONE;
        vMoveDirection = MoveDirection.NONE;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        LadderDetection();
        if (playerController.travelMode == PlayerController.TravelMode.DEFAULT)
        {
            DVMI();
            DHMI();
            BottomlessPlatform();
        }
        if (playerController.travelMode == PlayerController.TravelMode.LADDER)
        {
            LadderMovement();
        }
    }

    private void FixedUpdate()
    {
        HandlePhysics();
    }


    private void HandlePhysics()
    {
        if (playerController.travelMode == PlayerController.TravelMode.DEFAULT) { DefaultPhysics(); }
        if (playerController.travelMode == PlayerController.TravelMode.LADDER) { LadderPhysics(); }


    }

    private bool IsGrounded()
    {
        RaycastHit2D rayCastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayers);
        return rayCastHit.collider != null;
    }

    private void DVMI()
    {
        if (IsGrounded() && playerController.jumpCount!= 0) { playerController.jumpCount = 0; }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerController.jumpCount++;
            if (playerController.jumpCount < playerController.allocatedJumps)
            {
                vMoveDirection = MoveDirection.UP;
            }
        }
    } // Default Vertical Movement Input

    private void DHMI()
    {
        if (Input.GetKey(KeyCode.D)) { 
            hMoveDirection = MoveDirection.LEFT;
            spriteRenderer.flipX = false;
            Debug.Log(transform.localScale.x);
        }
        else if (Input.GetKey(KeyCode.A)) { 
            hMoveDirection = MoveDirection.RIGHT;
            spriteRenderer.flipX = true;
        }
        else { hMoveDirection = MoveDirection.NONE; }
    } // Default Horizontal Movement Input

    private void LadderMovement()
    {
        if (Input.GetKey(KeyCode.W)) { ladderDirection = LadderDirection.UP; }
        else if (Input.GetKey(KeyCode.S)) { ladderDirection = LadderDirection.DOWN; }
        else { ladderDirection = LadderDirection.NONE; }
    } 

    private void LadderDetection()
    {
        if (Input.GetKeyDown(KeyCode.Space) && ladderController.withinLadder == true) 
        {
            if (playerController.travelMode == PlayerController.TravelMode.LADDER)
            {
                playerController.AssignTravelModeDefault(rigidBody);
            }
            else
            {
                playerController.AssignTravelModeLadder(rigidBody);
            }
        }
    }

    private void DefaultPhysics()
    {
        switch (hMoveDirection)
        {
            case MoveDirection.LEFT:
                rigidBody.velocity = new Vector2(movementSpeed, rigidBody.velocity.y);
                break;
            case MoveDirection.RIGHT:
                rigidBody.velocity = new Vector2(-movementSpeed, rigidBody.velocity.y);
                break;
            case MoveDirection.NONE:
                rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
                break;
        }

        if (vMoveDirection == MoveDirection.UP)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpPower);
            Physics2D.IgnoreLayerCollision(3, 7, true);
            vMoveDirection = MoveDirection.NONE;
        }
    }
    private void LadderPhysics()
    {
        switch (ladderDirection)
        {       
            case LadderDirection.UP:
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, ladderController.vLadderSpeed);
                break;
            case LadderDirection.DOWN:
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, -ladderController.vLadderSpeed);
                break;
            case LadderDirection.NONE:
                rigidBody.velocity = Vector2.zero;
                break;
        }
    }

    private void BottomlessPlatform()
    {
        if (rigidBody.velocity.y < Mathf.Epsilon)
        {
            Utilities.SetPlayerPlatformCollision(true);
        }
    }

}
