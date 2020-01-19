using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sydney : Character
{
    
    public Sydney()
    {
        id = 1;
        name = "Sydney";
        story = "Strong sea anemone with a rough childhood full of unfortunate series of events. " +
            "Dislikes the idea of teams and loves to help his friends.";
        loveArray = new int[] { 2, 6, 1, 2, 9, 7 };
    }
    public override void doComboAttack(List<int> teamate, List<int> ennemies)
    {
        //Everyone in the roster loses faith in humanity and lose some love for each character in the current roster
        // But gain love for Sydney
        Debug.Log("Sydney talks about his rough childhood to his ennemies. They all start gaining sympathy and love for him and his teamate " + Game.roster[teamate[0]].name);

        foreach (int ennemy in ennemies)
        {
            Character c = Game.roster[ennemies[ennemy]];
            c.loveArray[id] += 4;
            c.loveArray[teamate[0]] += 2;
            Debug.Log("\t" + c.name + " has gained a lot of love for Sydney and a bit for " + Game.roster[teamate[0]].name);
        }

        List<int> currentRoster = new List<int>();
        currentRoster.Add(teamate[0]);
        currentRoster.Add(ennemies[0]);
        currentRoster.Add(ennemies[1]);

        Debug.Log("Everyone has lost a bit of faith in Humanity ... and love for the others ...");

        foreach (int c in currentRoster)
        {
            for (int i = 0; i < 6; i++)
            {
                if (i != id)
                    Game.roster[c].loveArray[i] -= 1;
            }
        }






    }


    public override void doUltimate()
    {
        // Sells sea weed, poisining his ennemies (who he likes less and boosting the people he likes, doesnt care about teams)
    }
}
