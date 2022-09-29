using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionController : MonoBehaviour
{
    private LadderController ladderController;
    private PlayerController playerController;
    private Rigidbody2D rigidBody;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        ladderController = GetComponent<LadderController>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            ladderController.ToggleWithinLadder();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            ladderController.ToggleWithinLadder();
            playerController.AssignTravelModeDefault(rigidBody);
        }
    }


}
