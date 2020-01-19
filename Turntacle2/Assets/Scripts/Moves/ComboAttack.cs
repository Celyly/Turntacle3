using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboAttack : Attack
{

    public ComboAttack(int nbOfTargets, int attackPower)
    {
        this.nbOfTargets = nbOfTargets;
        this.attackPower = attackPower;
    }
    public override void attack(List<Character> targets, double percentageBoost = 0, double percentageStrBoost = 0)
    {
        throw new System.NotImplementedException();
    }
}
