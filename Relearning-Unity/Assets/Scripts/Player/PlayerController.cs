using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float defaultGravity;
    public int jumpCount = 0;

    private void Start()
    {
        PlayerControllerSetup();
        defaultGravity = GetComponent<Rigidbody2D>().gravityScale;
    }

    public enum TravelMode { DEFAULT, TRIPLE, JETPACK, LADDER }
    public enum CombatMode { DEFAULT, BOOMERANG }
    public enum Items { BOOMERANG, JETPACK, TRIPLE }
    public CombatMode combatMode { get; set; }
    public TravelMode travelMode { get; set; }


    public void PlayerControllerSetup()
    {
        combatMode = CombatMode.DEFAULT;
        travelMode = TravelMode.DEFAULT;
    }

    public void AssignTravelModeDefault(Rigidbody2D rigidbody)
    {
        rigidbody.gravityScale = defaultGravity;
        travelMode = TravelMode.DEFAULT;
        jumpCount = 0;
    }

    public void AssignTravelModeTriple(Rigidbody2D rigidbody)
    {

    }

    public void AssignTravelModeJetPack(Rigidbody2D rigidbody)
    {

    }

    public void AssignTravelModeLadder(Rigidbody2D rigidbody)
    {
        rigidbody.gravityScale = 0;
        travelMode = TravelMode.LADDER;
    }



}


