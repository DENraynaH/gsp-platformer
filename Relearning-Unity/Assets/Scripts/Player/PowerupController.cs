using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupController : MonoBehaviour
{
    private PlayerController playerController;
    private int _allocatedJumps;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        _allocatedJumps = playerController.allocatedJumps;
    }


    public void OnTripleJumpCollect(GameObject powerUp, float duration)
    {
        Destroy(powerUp);
        playerController.allocatedJumps = 3;
        StartCoroutine(RemoveTripleJumpAfter(duration));
    }

    IEnumerator RemoveTripleJumpAfter(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        playerController.allocatedJumps = _allocatedJumps;
    }
}
