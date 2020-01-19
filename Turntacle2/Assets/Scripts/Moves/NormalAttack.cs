using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAttack : Attack
{
    public NormalAttack()
    {
        attackPower = 15;
        nbOfTargets = 1;
    }

    public override void attack(List<Character> targets, double percentageBoost = 0, double percentageStrBoost = 0)
    {
        foreach (Character c in targets)
            c.attack((int)(attackPower + attackPower * percentageBoost / 100));

    }
}
