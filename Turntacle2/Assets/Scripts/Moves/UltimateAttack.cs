using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateAttack : Attack
{

    public UltimateAttack(int nbOfTargets, int attackPower)
    {
        this.nbOfTargets = nbOfTargets;
        this.attackPower = attackPower;
    }
    public override void attack(List<Character> targets, double percentageBoost = 0, double percentageStrBoost = 0)
    {

    }
}
