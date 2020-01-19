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

        loveArray = new int[] { 3, 4, 10 , 5, 3, 4 };

        comboName = "Find most confident fish";
        ultimateName = "Instigate conflict";

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

        } else if (ennemies.Contains(indexMaxConfidence))
        {
            Debug.Log("Ellie has spotted a confident person in the ennemy team.");
            if (maxConf > loveArray[id])
            {
                Debug.Log("Ellie is feeling threatened, she is raising her defense .. ");
                defense += 20;
            }
            else
            {
                Debug.Log("Ellie is feeling more confident, she attacks " + Game.roster[indexMaxConfidence]);
                List<Character> target = new List<Character>();
                target.Add(Game.roster[indexMaxConfidence]);
                doAttack(target);
            }
        }
        else if (indexMaxConfidence == id)
        {
            // she is the most confident person 
            Debug.Log("Ellie is the most confident person in the roster, her strength raises by a bit ");
            strength += 5;

            if (strength > 100)
                strength = 100;

        }
            
    }

    public override void doUltimate(List<int> teamate, List<int> ennemies)
    {
        if (!hasUlted)

        {
            // She attacks a random enemy and shames him. Which makes his teamate lose half the love he had for him
            Character toShame;
            int random;
            if (Random.value < 0.5f)
                random = 0;
            else
                random = 1;

            toShame = Game.roster[ennemies[random]];
            // attack him
            Debug.Log(" Ellie attacks " + toShame.name + " and puts him to shame.");
            List<Character> target = new List<Character>();
            target.Add(toShame);
            doAttack(target);

            // his teamate gets ashamed of him, loses his relationship

            Character other;
            if (random == 1)
                other = Game.roster[ennemies[0]];
            else
                other = Game.roster[ennemies[1]];

            Debug.Log(other.name + " is ashamed of his teamate and loses his respect.");
            other.loveArray[toShame.id] -= 3;

            hasUlted = true;
        }
        else
        {
            Debug.Log("Ellie has shamed enough ennemies for now ..");
        }
        



    }
}
