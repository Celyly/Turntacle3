using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public GameObject speech;

    public GameObject teamObj1;
    public GameObject teamObj2;
    public GameObject title1, title2;

    public Text name1, name2, name3, name4;
    public Text description;

    public AudioSource titleMusic;

    public AudioSource curt;
    public AudioSource sydney;
    public AudioSource ellie;
    public AudioSource wess;
    public AudioSource joao;
    public AudioSource taylor;

    public List<int> arrayIndex = new List<int>();

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

    public void Start()
    {

        choices = new List<GameObject>();
        borderList = new List<GameObject>();
        tags = new List<string>();

        initialiseChoices();
        findAllBorders();
        loadAllSprites();
        initializeAllSprites();
        initialiseAllHeroes();

        currentPlayer = 1;
        currentIndexSelection = 0;
        currentCharacterLoaded = 0;

        currentColor = Color.blue;
        defaultColor = borderList[1].GetComponent<SpriteRenderer>().color;

        // First player selects the first character by default
        for (int i = 0; i < 2; i++)
        {
            Transform child = choices[0].transform.GetChild(i);

            if (child.tag == "border")
            {
                child.GetComponent<SpriteRenderer>().color = Color.blue;
            }
        }
        title1.GetComponent<Animator>().enabled = true;
        title2.GetComponent<Animator>().enabled = true;

    }

    public void initialiseAllHeroes()
    {
        teamObj1.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().sprite = null;
        teamObj1.transform.GetChild(1).GetChild(0).GetComponent<SpriteRenderer>().sprite = null;
        teamObj2.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().sprite = null;
        teamObj2.transform.GetChild(1).GetChild(0).GetComponent<SpriteRenderer>().sprite = null;
    }

    public void initializeAllSprites()
    {
        teamObj1.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().sprite = null;
        teamObj1.transform.GetChild(1).GetChild(0).GetComponent<SpriteRenderer>().sprite = null;
        teamObj2.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().sprite = null;
        teamObj2.transform.GetChild(1).GetChild(0).GetComponent<SpriteRenderer>().sprite = null;

        teamObj2.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().color = Color.white;
        teamObj2.transform.GetChild(1).GetChild(0).GetComponent<SpriteRenderer>().color = Color.white;
        teamObj2.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().color = Color.white;
        teamObj2.transform.GetChild(1).GetChild(0).GetComponent<SpriteRenderer>().color = Color.white;
    }

    public void changeBorderColor(int index, Color color)
    {
        // Change border color
        borderList[index].GetComponent<SpriteRenderer>().color = color;
        currentIndexSelection = index;
    }

    public void loadAllSprites()
    {
        foreach (GameObject sprite in choices)
        {
            sprites.Add(sprite.transform.GetChild(0).GetComponent<SpriteRenderer>());
        }
    }

    public void initialiseAllBordersColor()
    {
        foreach (GameObject border in borderList)
        {
            border.GetComponent<SpriteRenderer>().color = defaultColor;
        }
    }


    void getPlayerInputs()
    {

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (currentIndexSelection > 4)
            {
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

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (currentPlayer == 1)
            {
                if (!containsCharacterIn(teamObj1))
                {

                    if (currentIndexSelection == 0) curt.Play();
                    if (currentIndexSelection == 1) sydney.Play();
                    if (currentIndexSelection == 2) ellie.Play();
                    if (currentIndexSelection == 3) wess.Play();
                    if (currentIndexSelection == 4) joao.Play();
                    if (currentIndexSelection == 5) taylor.Play();

                    arrayIndex.Add(currentIndexSelection);

                    game.team1.addCharacter(currentIndexSelection);
                    teamObj1.transform.GetChild(currentCharacterLoaded).GetChild(0).GetComponent<SpriteRenderer>().color = Color.white;
                    currentPlayer++;
                    currentColor = Color.red;
                    teamObj1.transform.GetChild(currentCharacterLoaded).GetChild(0).tag = choices[currentIndexSelection].transform.GetChild(0).tag;
                    tags.Add(choices[currentIndexSelection].transform.GetChild(0).tag.ToString());
                    teamObj1.transform.GetChild(currentCharacterLoaded).GetChild(0).GetComponent<Animator>().enabled = true;
                    teamObj1.transform.GetChild(currentCharacterLoaded).GetChild(0).GetComponent<Animator>().runtimeAnimatorController = choices[currentIndexSelection].transform.GetChild(0).GetComponent<Animator>().runtimeAnimatorController;



                }
            }
            else
            {
                if (!containsCharacterIn(teamObj2))
                {


                    if (currentIndexSelection == 0) curt.Play();
                    if (currentIndexSelection == 1) sydney.Play();
                    if (currentIndexSelection == 2) ellie.Play();
                    if (currentIndexSelection == 3) wess.Play();
                    if (currentIndexSelection == 4) joao.Play();
                    if (currentIndexSelection == 5) taylor.Play();

                    arrayIndex.Add(currentIndexSelection);
                    game.team2.addCharacter(currentIndexSelection);
                    teamObj2.transform.GetChild(currentCharacterLoaded).GetChild(0).GetComponent<SpriteRenderer>().color = Color.white;

                    currentPlayer--;
                    currentColor = Color.blue;

                    teamObj2.transform.GetChild(currentCharacterLoaded).GetChild(0).tag = choices[currentIndexSelection].transform.GetChild(0).tag;
                    tags.Add(choices[currentIndexSelection].transform.GetChild(0).tag.ToString());
                    teamObj2.transform.GetChild(currentCharacterLoaded).GetChild(0).GetComponent<Animator>().enabled = true;
                    teamObj2.transform.GetChild(currentCharacterLoaded).GetChild(0).GetComponent<Animator>().runtimeAnimatorController = choices[currentIndexSelection].transform.GetChild(0).GetComponent<Animator>().runtimeAnimatorController;
                    currentCharacterLoaded++;


                    if (currentCharacterLoaded == 2)
                    {
                        // CHARACTER SELECT IS DONE
                        isDone = true;
                        title1.GetComponent<Animator>().enabled = false;
                        title2.GetComponent<Animator>().enabled = false;
                        title1.SetActive(false);
                        title2.SetActive(false);
                        game.gamePlay.gameObject.SetActive(true);
                        game.gamePlay.isPlaying = true;

                        // set team for the upcoming round
                        game.gamePlay.team1 = game.team1;
                        game.gamePlay.team2 = game.team2;


                        changeBorderColor(currentIndexSelection, defaultColor);
                        //reset texts
                        name1.text = "";
                        name2.text = "";
                        name3.text = "";
                        name4.text = "";
                        speech.SetActive(true);

                        //titleMusic.Stop();

                    }


                }
            }
        }


        //suite




    }

    int findIndex(string tag)
    {
        for (int i = 0; i < tags.Count; i++)
        {
            if (tags[i].ToString() == tag)
            {
                return i;
            }
        }
        return 0;
    }

    bool containsCharacterIn(GameObject team)
    {


        if (tags.Contains(choices[currentIndexSelection].transform.GetChild(0).tag.ToString()))
        {
            return true;
        }
        return false;

    }

    public void detectRelationship(GameObject teamObj, Team team, int index, int teammateIndex)
    {
        int loveValue = Game.roster[team.playingCharacters[index]].loveArray[teammateIndex];
        if (loveValue < 4)
        {
            //small heart
            teamObj.transform.GetChild(index).GetChild(0).GetComponent<Animator>().SetInteger("state", 1);
        }
        else
        {
            if (loveValue > 6)
            {
                //big heart
                teamObj.transform.GetChild(index).GetChild(0).GetComponent<Animator>().SetInteger("state", 2);
            }
            else
            {
                //medium
                teamObj.transform.GetChild(index).GetChild(0).GetComponent<Animator>().SetInteger("state", 0);
            }
        }
    }

    public void changeAnimation()
    {
        // Player 1

        // Character #1
        if (game.team1.playingCharacters.Count == 1 && currentPlayer == 1)
        {
            detectRelationship(teamObj1, game.team1, 0, currentIndexSelection);

        }
        // Character #2
        else if (game.team1.playingCharacters.Count > 1)
        {
            detectRelationship(teamObj1, game.team1, 1, game.team1.playingCharacters[0]);
        }


        // Player 2
        // Character #1
        if (game.team2.playingCharacters.Count == 1 && currentPlayer == 2)
        {
            detectRelationship(teamObj2, game.team2, 0, currentIndexSelection);
        }
        // Character #2
        else if (game.team2.playingCharacters.Count > 1)
        {
            detectRelationship(teamObj2, game.team2, 1, game.team2.playingCharacters[0]);
        }

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

    void showLove()
    {
        for (int i = 0; i < choices.Count; i++)
        {
            if (Game.roster[currentIndexSelection].loveArray[i] < 4)
            {
                //small heart
                choices[i].transform.GetChild(2).transform.localScale = new Vector3(0.1f + 0.05f * Game.roster[currentIndexSelection].loveArray[i], 0.1f + 0.05f * Game.roster[currentIndexSelection].loveArray[i], 0.1f + 0.05f * Game.roster[currentIndexSelection].loveArray[i]);
            }
            else
            {
                if (Game.roster[currentIndexSelection].loveArray[i] > 6)
                {
                    //big heart
                    choices[i].transform.GetChild(2).transform.localScale = new Vector3(0.1f + 0.05f * Game.roster[currentIndexSelection].loveArray[i], 0.1f + 0.05f * Game.roster[currentIndexSelection].loveArray[i], 0.1f + 0.05f * Game.roster[currentIndexSelection].loveArray[i]);
                }
                else
                {
                    //medium
                    choices[i].transform.GetChild(2).transform.localScale = new Vector3(0.1f + 0.05f * Game.roster[currentIndexSelection].loveArray[i], 0.1f + 0.05f * Game.roster[currentIndexSelection].loveArray[i], 0.1f + 0.05f * Game.roster[currentIndexSelection].loveArray[i]);
                }
            }
        }
    }

    public void changeScale()
    {
        switch (currentIndexSelection)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            default:
                break;
        }
    }


    public void ShowFullDescription()
    {
        description.text = Game.roster[currentIndexSelection].story;
        description.text += "\n\nCombo: " + Game.roster[currentIndexSelection].comboName
            + "\nUltimate: " + Game.roster[currentIndexSelection].ultimateName;
    }


    // Update is called once per frame
    void Update()
    {

        if (!isDone)
        {
            changeBorderColor(currentIndexSelection, currentColor);
            showShadow();
            getPlayerInputs();
            showLove();
            changeAnimation();
            ShowFullDescription();

            // update description and name
            if (currentPlayer == 1)
            {
                if (game.team1.playingCharacters.Count == 0)
                {
                    name1.text = Game.roster[currentIndexSelection].name;

                }
                else
                {
                    name2.text = Game.roster[currentIndexSelection].name;
                }
            }
            else
            {
                if (game.team2.playingCharacters.Count == 0)
                {
                    name3.text = Game.roster[currentIndexSelection].name;

                }
                else
                {
                    name4.text = Game.roster[currentIndexSelection].name;
                }
            }
        }
    }
}
