using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Character
{
    public static double attackPower = 30;
    public int id;
    public string name;
    public string story;
    // names of abilities
    public string comboName,ultimateName;
  

    


    // arrays for relations
    public int[] loveArray = new int[6];

    //stats 

    public int health = 100;  // 0 to a hundred

    public int strength = 70; // from 0 to 100 : 70 is the base strength
    public int defense = 50;
    public bool hasUlted = false;
   
    // move fields
    public NormalAttack normalAttack = new NormalAttack();
    public UltimateAttack ultimateAttack;
    public ComboAttack comboAttack;

    public void doDefense()
    {
        defense += 20;
        //USE CHARGE ANIMATION TO SHOW DEFENSE
    }

    public void resetDefense() //called at the beginning of a turn
    {
        defense = 50;
    }


    public void doAttack(List<Character> target){

        double attackDmg = attackPower + attackPower * (double)(strength - 100) / 100;
        target[0].attack((int)attackDmg);
        Debug.Log(name + " attacked " + target[0].name + " for " + attackDmg + " damage.");
        Debug.Log(target[0].name + " has now " + target[0].health + " health");
    }



    // CAN BE DONE ONCE PER GAME
    public abstract void doUltimate(List<int> teamate, List<int> ennemies);

    public abstract void doComboAttack(List<int> teamate, List<int> ennemies);
    


    public string printState()
    {
        // return the state of the characters (love array) 

        return null;
    }

    /**
     * return false if dead returns true if alive
     * */

    public bool attack(int hpRemoved)
    {
        health -= hpRemoved;
        if (health >= 100)
        {
            health = 100;
            return true;
        }

        if (health <= 0)
        {
            health = 0;
            return false;
        }
         return true;
    }
    
    public static int findMax(int[]array)
    {
        int max = 0;
        int indexMax = 0;
        for(int i = 0; i < 6; i++)
        {
             if(array[i] > max)
            {
                max = array[i];
                indexMax = i;
            }
        }
        return max;
    }

    public static int findMin(int[] array)
    {
        int min = 100;
        int indexMin = 0;
        for(int i = 0; i < 6; i++)
        {
            if(array[i] < min)
            {
                min = array[i];
                indexMin = i;
            }
        }

        return indexMin;
    }

    public void reset()
    {
        health = 100;
        hasUlted = false;
        resetDefense();
    }
}
