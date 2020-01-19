using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wess : Character
{
    public Wess()
    {
        id = 3;
        name = "Wess";
        story = "A really cool kraken with a not so cool love for stealing ladies. " +
            "Loves to rub his tentacles together.";
        loveArray = new int[] { 0, 5, 10, 8, 0, 10 };

    }
    public override void doComboAttack(List<int> teamate, List<int> ennemies)
    {
        // Condition: if the person Wess like the most is with the person Wess hates the most
        // super jealousy kicks in and he steals her for a turn and attacks the other.

        int love = findMax(this.loveArray);
        int hate = findMin(this.loveArray);

        if (ennemies.Contains(love) && ennemies.Contains(hate))
        {
            Game.roster[love].strength /= 2; //haha loser now youre weak!
            Debug.Log("Wess steals the heart of his love! Their strength is halved!");
            //GOTTA RESET AFTER
            doAttack(new List<Character>() { Game.roster[hate] });
            Debug.Log("Wess also attacks his rival!");
            this.loveArray[hate] += 3;
            Debug.Log("Wess thinks his rival is nice for letting him steal his love back!" +
                "Friendship with " + Game.roster[hate].name + " now at " + this.loveArray[hate]);
            Game.roster[love].loveArray[this.id] -= 4;
            Debug.Log("Wess' love isn't impressed by his jealousy! Friendship now at " +
                Game.roster[love].loveArray[this.id]);
        }

        Debug.Log("Combo move cannot be used now!");


    }

    public override void doUltimate()
    {
        //Attacks while rubbing hands together, deals extra damage and lowers other opponents
        //attack stat. 

    }
}
