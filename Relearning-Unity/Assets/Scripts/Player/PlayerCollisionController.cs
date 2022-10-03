using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerCollisionController : MonoBehaviour
{
    private LadderController ladderController;
    private PlayerController playerController;
    private PowerupController powerupController;
    private Rigidbody2D rigidBody;

    private void Start()
    {
        powerupController = GetComponent<PowerupController>();
        playerController = GetComponent<PlayerController>();
        ladderController = GetComponent<LadderController>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            ladderController.ToggleWithinLadder();
            playerController.withinLadder = collision.gameObject;
        }
        else if (collision.gameObject.CompareTag("TripleJump"))
        {
            powerupController.OnTripleJumpCollect(collision.gameObject, 5f);
        }
        else if (collision.gameObject.CompareTag("Jetpack"))
        {

        }
    }
     
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            ladderController.ToggleWithinLadder();
            playerController.AssignTravelModeDefault(rigidBody);
        }
        else if (collision.gameObject.CompareTag("TripleJump"))
        {
            
        }
        else if (collision.gameObject.CompareTag("Jetpack"))
        {

        }
    }


}
