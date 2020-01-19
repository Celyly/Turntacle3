using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ellie : Character
{
    public Ellie()
    {
        id = 2;
        name = "Ellie";
        story = "Smart dumbo octopus that loves herself a little bit too much. Has a little bit of an anger management issue.";

        loveArray = new int[] { 3, 4, 10, 5, 3, 4 };
    }


    public override void doComboAttack(List<int> teamate, List<int> ennemies)
    {

        List<int> currentRoster = new List<int>();
        currentRoster.Add(teamate[0]);
        currentRoster.Add(ennemies[0]);
        currentRoster.Add(ennemies[1]);

        int maxConf = 0;
        int indexMaxConfidence = 0;
        // takes the most cofident person in the roster beside her
        for (int i = 0; i < 6; i++)
        {

            if (Game.roster[i].loveArray[Game.roster[i].id] > maxConf)
            {
                maxConf = Game.roster[i].loveArray[Game.roster[i].id];
                indexMaxConfidence = Game.roster[i].id;
            }

        }

        // if person is in team she will get jealous and lower her strength
        if (indexMaxConfidence == teamate[0])
        {
            Debug.Log("Ellie is jealous of her teamate's confidence. She loses some strength ...");
            strength -= 20;
            if (strength < 0)
                strength = 0;

        }

    }

    public override void doUltimate()
    {
        throw new System.NotImplementedException();
    }
}
