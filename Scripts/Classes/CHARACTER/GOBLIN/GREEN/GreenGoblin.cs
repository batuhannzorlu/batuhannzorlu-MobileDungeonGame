using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenGoblin : Goblin
{
    public GreenGoblin()
    {
        this.SetHealth(100);
        this.SetDefense(100);
        this.SetDamage(80);
        this.SetMoveSpeeed(100);
        this.SetType("GreenGoblin");
        this.SetCriticalDamage(100);
        this.SetCriticalPercentage(100);
        this.SetAttackSpeed(100);
        this.SetVisionDistance(100);
    }

}
