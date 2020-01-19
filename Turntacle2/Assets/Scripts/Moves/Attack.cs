using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack
{
    public int attackPower;
    public int nbOfTargets;


    public void execute(List<Character> targets, double percentageAttBoost = 0, double percentageStrBoost = 0)
    {
        if (targets.Count < nbOfTargets)
            Debug.Log("!!!!!!!!!! NOT ENOUGH TARGETS !!!!!!!!!");
        else if (targets.Count > nbOfTargets)
            Debug.Log("!!!!!!!!!! TOO MUCH TARGET FOR THIS ATTACK !!!!!!!!");
        attack(targets, percentageAttBoost, percentageStrBoost);
    }

    public abstract void attack(List<Character> targets, double percentageBoost = 0, double percentageStrBoost = 0);

}
