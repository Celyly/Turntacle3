using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curt : Character
{
    
    
    public Curt() {
        // Everytime he wins, he loves himself more. The more he loves himself the more he should 
        // have a diffcult time with his abilities.
        // For example : His ultimate can be, He hits the person of has the more confidence in the team
        id = 0;
        name = "Kurt the Hurt";
        story = "Young emo cuttlefish that hates people, but none more than himself." +
            "He is stronger agaisn't fishes he hates."; 
        loveArray = new int[]{0,5,10,2,7,4};

        comboName = "Give a gift";
        ultimateName = "Attack the healthy";

    }

    public override void doComboAttack(List<int>teamate,List<int>ennemies)
    {
        //Condition : If the person he likes the most is in the roster, he will pass the knife to that character
        // If the character doesnt like him enough (char likes kurt > 5) he will refuse the knife.

        // check if the char he likes the most is in the roster.
        int indexLikesMost = findMax(loveArray);

        if(indexLikesMost == id)
        {
            
            Debug.Log("Kurt likes himself the most, he gifts himself another knife.");
            strength += 30;
            if (strength >= 100)
                strength = 100;
            Debug.Log(" Kurt's strength is now : " + strength);
        }
        List<int> currentRoster = new List<int>();
        currentRoster.Add(teamate[0]);
        currentRoster.Add(ennemies[0]);
        currentRoster.Add(ennemies[1]);

        if (currentRoster.Contains(indexLikesMost))
        {
            Character mostLoved = Game.roster[indexLikesMost];
            Debug.Log("Kurt wants to give a gift to his beloved " + mostLoved.name);
            if (mostLoved.loveArray[id] < 5)
            {
                Debug.Log(mostLoved.name + " doesn't want Kurt's gift. Kurt's confidence is hurt.");
                loveArray[id] -= 1;
                Debug.Log("Kurt's love for himself is now : " + loveArray[id]);
            }
            else
            {
                Debug.Log(mostLoved.name + " Gladly accepts Kurt's gift.");
                mostLoved.strength += 10;
                if (mostLoved.strength >= 100)
                    mostLoved.strength = 100;
                Debug.Log(mostLoved.name + "'s strength is now : " + mostLoved.strength);

            }

        }
       
    }

    
    public override void doUltimate(List<int> teamate, List<int> ennemies)
    {
        // Attack the weak 
        // attacks the person with the least health the more he hates them 
        List<int> currentRoster = new List<int>();
        currentRoster.Add(teamate[0]);
        currentRoster.Add(ennemies[0]);
        currentRoster.Add(ennemies[1]);

        if (!hasUlted)
        {
            int maxHealth = 0;
            Character strongestChar = Game.roster[ennemies[0]];
            foreach(int c in ennemies)
            {
                if (Game.roster[c].health > maxHealth)
                {
                    maxHealth = Game.roster[c].health;
                    strongestChar = Game.roster[c];
                }
            }

            // attacks the most healthy person depending on how much he hates him
            int hate = 10 - loveArray[strongestChar.id];
            List<Character> target = new List<Character>();
            target.Add(strongestChar);
            // get him stronger according to his hate to that character and attack
            double oldAttPower = attackPower;
            attackPower = hate * 2;
            strongestChar.doAttack(target);
            attackPower = oldAttPower;


            hasUlted = true;
        }
        else
        {
            Debug.Log("Kurt has already ulted this round.");
        }
       
    }
}
