using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// selectionner les charactere et remplir les teams
public class CharacterSelection : MonoBehaviour
{
    // Start is called before the first frame update

    public Game game;

    public GameObject choice1;
    public GameObject choice2;
    public GameObject choice3;
    public GameObject choice4;
    public GameObject choice5;
    public GameObject choice6;

    public GameObject teamObj1;
    public GameObject teamObj2;


    public List<GameObject> choices;
    public List<GameObject> borderList;
    public List<SpriteRenderer> sprites;
    public List<string> tags;
    public int currentCharacterLoaded;

    //1 team 1, 2 team 2
    public int currentPlayer;
    public int currentIndexSelection;

    Color defaultColor;
    Color currentColor;

    public bool isDone = false;

    void findAllBorders()
    {
        for (int i = 0; i < choices.Count; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                GameObject child = choices[i].transform.GetChild(j).gameObject;

                if (child.tag == "border")
                {
                    borderList.Add(child);
                }
            }

        }
    }

    void initialiseChoices()
    {
        choices.Add(choice1);
        choices.Add(choice2);
        choices.Add(choice3);
        choices.Add(choice4);
        choices.Add(choice5);
        choices.Add(choice6);
    }

    void Start()
    {
        choices = new List<GameObject>();
        borderList = new List<GameObject>();
        tags= new List<string>();

        initialiseChoices();
        findAllBorders();
        loadAllSprites();
        initializeAllSprites();

        currentPlayer = 1;
        currentIndexSelection = 0;
        currentCharacterLoaded = 0;

        currentColor = Color.blue;
        defaultColor = borderList[1].GetComponent<SpriteRenderer>().color;

        // First player selects the first character by default
        for (int i = 0; i < 2; i++){
            Transform child = choices[0].transform.GetChild(i);
            
            if (child.tag == "border")
            {
                child.GetComponent<SpriteRenderer>().color = Color.blue;
            }
        }

    }


     void initializeAllSprites()
    {
        teamObj1.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().sprite = null;
        teamObj1.transform.GetChild(1).GetChild(0).GetComponent<SpriteRenderer>().sprite = null;
        teamObj2.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().sprite = null;
        teamObj2.transform.GetChild(1).GetChild(0).GetComponent<SpriteRenderer>().sprite = null;
    }

    void changeBorderColor(int index, Color color)
    {
        // Change border color
        borderList[index].GetComponent<SpriteRenderer>().color = color;
        currentIndexSelection = index ;
    }

    void loadAllSprites()
    {
        foreach(GameObject sprite in choices)
        {
            Debug.Log(sprite.transform.GetChild(0).name);
            sprites.Add(sprite.transform.GetChild(0).GetComponent<SpriteRenderer>());
        }
    }

    void initialiseAllBordersColor()
    {
        foreach(GameObject border in borderList)
        {
            border.GetComponent<SpriteRenderer>().color = defaultColor;
        }
    }


    void getPlayerInputs()
    {
            if (Input.GetKeyDown(KeyCode.D)) {
                if (currentIndexSelection > 4) {
                    currentIndexSelection = -1;
                }
                initialiseAllBordersColor();
                changeBorderColor(++currentIndexSelection, currentColor);
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (currentIndexSelection < 1)
                {
                    currentIndexSelection = 6;
                }
                initialiseAllBordersColor();

                changeBorderColor(--currentIndexSelection, currentColor);
            }

            if (Input.GetKeyDown(KeyCode.Return)) {
                if (currentPlayer == 1)
                {
                    if (!containCharact(teamObj1)) {

                        Debug.Log("currentPlayer: " + currentPlayer);
                        game.team1.addCharacter(currentIndexSelection);
                        teamObj1.transform.GetChild(currentCharacterLoaded).GetChild(0).GetComponent<SpriteRenderer>().color = Color.white;
                        currentPlayer++;
                        currentColor = Color.red;
                        teamObj1.transform.GetChild(currentCharacterLoaded).GetChild(0).tag = choices[currentIndexSelection].transform.GetChild(0).tag;
                        tags.Add(choices[currentIndexSelection].transform.GetChild(0).tag.ToString());
                        teamObj1.transform.GetChild(currentCharacterLoaded).GetChild(0).GetComponent<Animator>().runtimeAnimatorController = choices[currentIndexSelection].transform.GetChild(0).GetComponent<Animator>().runtimeAnimatorController;


                    }
                }
                else {
                    if (!containCharact(teamObj2)) {
                        game.team2.addCharacter(currentIndexSelection);
                        teamObj2.transform.GetChild(currentCharacterLoaded).GetChild(0).GetComponent<SpriteRenderer>().color = Color.white;
                        currentPlayer--;
                        currentColor = Color.blue;
                        teamObj2.transform.GetChild(currentCharacterLoaded).GetChild(0).tag = choices[currentIndexSelection].transform.GetChild(0).tag;
                        tags.Add(choices[currentIndexSelection].transform.GetChild(0).tag.ToString());
                        teamObj2.transform.GetChild(currentCharacterLoaded).GetChild(0).GetComponent<Animator>().runtimeAnimatorController = choices[currentIndexSelection].transform.GetChild(0).GetComponent<Animator>().runtimeAnimatorController;
                    currentCharacterLoaded++;
                        if (currentCharacterLoaded == 2)
                            isDone = true;

                    }
                }
            }
      

        //suite




    }

    bool containCharact(GameObject team) {

      
        if (tags.Contains(choices[currentIndexSelection].transform.GetChild(0).tag.ToString()))
        {
            return true;
        }

        
        

        return false;

    }
    void showShadow()
    {
        if (currentPlayer == 1)
        {
            teamObj1.transform.GetChild(currentCharacterLoaded).GetChild(0).GetComponent<SpriteRenderer>().sprite = sprites[currentIndexSelection].sprite;
            teamObj1.transform.GetChild(currentCharacterLoaded).GetChild(0).GetComponent<SpriteRenderer>().color = Color.black;

        }
        else
        {
            teamObj2.transform.GetChild(currentCharacterLoaded).GetChild(0).GetComponent<SpriteRenderer>().sprite = sprites[currentIndexSelection].sprite;
            teamObj2.transform.GetChild(currentCharacterLoaded).GetChild(0).GetComponent<SpriteRenderer>().color = Color.black;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
        if (!isDone)
        {
            changeBorderColor(currentIndexSelection, currentColor);
            showShadow();
            getPlayerInputs();
        }
        else
        {
            changeBorderColor(currentIndexSelection, defaultColor);

        }
       

        
    }
}
