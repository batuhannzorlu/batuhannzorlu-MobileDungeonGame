using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedGoblin : Goblin
{
    public RedGoblin()
    {
        this.SetHealth(300);
        this.SetDefense(300);
        this.SetDamage(240);
        this.SetMoveSpeeed(300);
        this.SetType("RedGoblin");
        this.SetCriticalDamage(300);
        this.SetCriticalPercentage(300);
        this.SetAttackSpeed(300);
        this.SetVisionDistance(300);
    }
}
