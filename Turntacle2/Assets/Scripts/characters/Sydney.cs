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

        comboName = "Gain Sympathy";
        ultimateName = "Give fishy sea weed";
    }
    public override void doComboAttack(List<int> teamate, List<int> ennemies)
    {
        //Everyone in the roster loses faith in humanity and lose some love for each character in the current roster
        // But gain love for Sydney
        Debug.Log("Sydney talks about his rough childhood to his ennemies. They all start gaining sympathy and love for him and his teamate " + Game.roster[teamate[0]].name);


        List<int> currentRoster = new List<int>();
        foreach(int ennemy in ennemies){
            Character c = Game.roster[ennemy];
            c.loveArray[id] += 2;
            c.loveArray[teamate[0]] += 1;
            Debug.Log("\t" + c.name + " has gained a lot of love for Sydney and a bit for " + Game.roster[teamate[0]].name);
        }

        currentRoster.Add(teamate[0]);
        currentRoster.Add(ennemies[0]);
        currentRoster.Add(ennemies[1]);

        Debug.Log("Everyone has lost a bit of faith in Humanity ... and love for the others ...");

        foreach (int c in currentRoster)
        {
            for(int i = 0; i<6; i++)
            {
                if(i != id && i != teamate[0]) 
                    Game.roster[c].loveArray[i] -= 1;
            }
        }

     }
   

    public override void doUltimate(List<int> teamate, List<int> ennemies)
    {
        // Sells sea weed, poisining his ennemies (who he likes less and boosting the people he likes, doesnt care about teams)

        if (!hasUlted)
        {
            List<int> currentRoster = new List<int>();
            currentRoster.Add(teamate[0]);
            currentRoster.Add(ennemies[0]);
            currentRoster.Add(ennemies[1]);

            foreach (int index in currentRoster)
            {
                if(Game.roster[index].loveArray[id] >= 7)
                {
                    Debug.Log(Game.roster[index].name + " accepted Sydney's sea weed");
                    
                    // if sydney likes the taker enough, he will give them good sea weed
                    //else he will poison them

                    if(loveArray[index] > 5)
                    {
                        // give good sea wood , heal
                        Debug.Log(Game.roster[index].name + " Got healed by the sea weed." + Game.roster[index].name + " admirers Sydney even more now.");
                        Game.roster[index].health += 30;
                        if (Game.roster[index].health > 100)
                            Game.roster[index].health = 100;
                        Game.roster[index].loveArray[id] += 2;

                    }
                    else
                    {
                        // give bad sea weed, poison
                        Debug.Log(Game.roster[index].name + " Got poisoned by the sea weed." + Game.roster[index].name + " hates Sydney even more now.");
                        Game.roster[index].health -= 30;
                        if (Game.roster[index].health < 1)
                            Game.roster[index].health = 1;
                        Game.roster[index].loveArray[id] -= 4;
                    }
                    
                }
            }

        }
        else
        {
            Debug.Log("Sydney has already sold his sea weed");
        }

    }

    public void writeDialog()
    {


    }
}
