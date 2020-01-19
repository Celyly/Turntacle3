using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taylor : Character
{

    public Taylor()
    {
        name = "Taylor";
        story = "A silly snake whose only dream is to one day become a big tentacle." +
            "She admires the thickest of tentacles around.";
        loveArray = new int[] { 5, 1, 7, 10, 6, 4 };

    }

    public override void doComboAttack(List<int> teamate, List<int> ennemies)
    {
        //If she really likes her teammate, she becomes one of their tentacles and boosts their 
        //attack like crazy!

        int love = findMax(this.loveArray);
        int hate = findMin(this.loveArray);

        if (teamate.Contains(love))
        {
            Game.roster[love].strength *= 2;
            this.loveArray[love] -= 3;
            Debug.Log("Taylor's partner is weirded out!" +
                " Friendship is now at " + this.loveArray[love] );
        }
        Debug.Log("Combo move cannot be used now!");
    }

    public override void doUltimate(List<int> teamate, List<int> ennemies)
    {
      
    }
}
