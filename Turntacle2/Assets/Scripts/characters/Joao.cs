using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joao : Character
{
    public Joao()
    {
        id = 4;
        name = "Joao";
        story = "Olá, sou o João e adoro frango piri piri.";
        loveArray = new int[] { 5, 1, 7, 10, 6, 4 };

    }

    public override void doComboAttack(List<int> teamate, List<int> ennemies)
    {
        // Joao is so chill that if his partner likes him the most, they chill out enough to heal!

        int love = findMax(this.loveArray);
        int hate = findMin(this.loveArray);

        if (teamate.Contains(love))
        {
            Game.roster[love].health += 30;
            Game.roster[love].loveArray[this.id] -= 3;
            Debug.Log("Oh no! Joao is too chill! He loses friendship... " +
                Game.roster[love].name + "'s love of Joao is now " +
                Game.roster[love].loveArray[this.id]);
        }
    }

    public override void doUltimate()
    {
        //Attacks while rubbing hands together, deals extra damage and lowers other opponents
        //attack stat. 

    }
}
