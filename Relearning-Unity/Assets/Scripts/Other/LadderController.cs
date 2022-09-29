using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderController : MonoBehaviour
{
    public float vLadderSpeed = 0.5f;
    public float hLadderSpeed = 0.5f;
    public bool withinLadder;

    public void ToggleWithinLadder()
    {
        if (withinLadder == true) { withinLadder = false;  }
        else { withinLadder = true; }
    }

    

}
