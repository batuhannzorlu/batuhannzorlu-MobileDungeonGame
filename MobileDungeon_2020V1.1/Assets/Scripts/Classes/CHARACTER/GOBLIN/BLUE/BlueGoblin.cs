using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueGoblin : Goblin
{
    public BlueGoblin()
    {
        this.SetHealth(200);
        this.SetDefense(200);
        this.SetDamage(200);
        this.SetMoveSpeeed(200);
        this.SetType("BlueGoblin");
        this.SetCriticalDamage(200);
        this.SetCriticalPercentage(200);
        this.SetAttackSpeed(200);
        this.SetVisionDistance(200);
    }
}
