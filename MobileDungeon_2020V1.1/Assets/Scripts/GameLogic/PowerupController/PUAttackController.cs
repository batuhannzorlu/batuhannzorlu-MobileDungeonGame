using Assets.Scripts.Classes.ITEM.POWERUP;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUAttackController : MonoBehaviour
{
   public PUAttack ReferencePowerup;
    void Start() { ReferencePowerup = new PUAttack(this.gameObject); }
    
        
    

}
