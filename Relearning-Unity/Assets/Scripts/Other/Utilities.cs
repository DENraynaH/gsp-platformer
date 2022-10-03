using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public static class Utilities
{
    public static void SetPlayerPlatformCollision(bool status)
    {
        if (status == true) { Physics2D.IgnoreLayerCollision(3, 7, false); }
        else { Physics2D.IgnoreLayerCollision(3, 7, true); }
    }

    public static void ShakeObject(GameObject gameObject, float amount)
    {

    }

}
