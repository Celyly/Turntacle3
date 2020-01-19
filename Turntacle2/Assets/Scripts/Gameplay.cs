using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// le jeu avec les regles etc
public class Gameplay : MonoBehaviour
{
    public CharacterSelection characterSelection;
    public int turn = 1;
    public int indexCurrentChar = 0;
    public Team team1, team2;
    public bool isPlaying = false;

    public AudioSource fight;

    public AudioSource curt;
    public AudioSource sydney;
    public AudioSource ellie;
    public AudioSource wess;
    public AudioSource joao;
    public AudioSource taylor;

    public AudioSource curtU;
    public AudioSource sydneyU;
    public AudioSource ellieU;
    public AudioSource wessU;
    public AudioSource joaoU;
    public AudioSource taylorU;

    public bool waitingForTargetInput = false;
    public bool waitingForMoveInput = false;
    public bool debuggedOnce = false;
    string moveInput = "",targetInput = "";

    public GameObject sprite1, sprite2, sprite3, sprite4;
    public GameObject hp1, hp2, hp3, hp4;

    public GameObject speech;
    public Text dialogText;
    public Animator anim;

    // Start is called before the first frame update
    public void Start()
    {

        //fight.Play();

        turn = 1; // 1 = player1 ...
        indexCurrentChar = 0;
        isPlaying = false;

        waitingForTargetInput = false;
        waitingForMoveInput = false;
        debuggedOnce = false;
        moveInput = "";
        targetInput = "";
       
}

    // Update is called once per frame
    void Update()
    {
        if (this.enabled)
        {
            anim.SetTrigger("PopupTrigger");
        }

        if (isPlaying)
        {

            hp1.transform.parent.gameObject.SetActive(true);
            hp2.transform.parent.gameObject.SetActive(true);
            hp3.transform.parent.gameObject.SetActive(true);
            hp4.transform.parent.gameObject.SetActive(true);
            hp1.GetComponent<Bar>().setValue(Game.roster[team1.playingCharacters[0]].health/100f, false);
            hp2.GetComponent<Bar>().setValue(Game.roster[team1.playingCharacters[1]].health/100f,false);
            hp3.GetComponent<Bar>().setValue(Game.roster[team2.playingCharacters[0]].health/100f, false);
            hp4.GetComponent<Bar>().setValue(Game.roster[team2.playingCharacters[1]].health/100f, false);


            if (Game.roster[team1.playingCharacters[0]].health == 0){
              
                sprite1.transform.GetChild(0).GetComponent<SpriteRenderer>().flipY = true;
                sprite1.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.black;
                Color tmp = sprite1.transform.GetChild(0).GetComponent<SpriteRenderer>().color;
                tmp.a = 0.5f;
                sprite1.transform.GetChild(0).GetComponent<SpriteRenderer>().color = tmp;

                sprite1.transform.GetChild(0).GetComponent<Animator>().enabled = false;
                
                }
                if (Game.roster[team1.playingCharacters[1]].health == 0)
                {
                sprite2.transform.GetChild(0).GetComponent<SpriteRenderer>().flipY = true;
                sprite2.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.black;
                Color tmp = sprite2.transform.GetChild(0).GetComponent<SpriteRenderer>().color;
                tmp.a = 0.5f;
                sprite2.transform.GetChild(0).GetComponent<SpriteRenderer>().color = tmp;
                sprite2.transform.GetChild(0).GetComponent<Animator>().enabled = false;
            }


                if (Game.roster[team2.playingCharacters[0]].health == 0)
                {
                sprite3.transform.GetChild(0).GetComponent<SpriteRenderer>().flipY = true;
                sprite3.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.black;
                Color tmp = sprite3.transform.GetChild(0).GetComponent<SpriteRenderer>().color;
                tmp.a = 0.5f;
                sprite3.transform.GetChild(0).GetComponent<SpriteRenderer>().color = tmp;
                sprite3.transform.GetChild(0).GetComponent<Animator>().enabled = false;
            }
                if (Game.roster[team2.playingCharacters[1]].health == 0)
                {
                sprite4.transform.GetChild(0).GetComponent<SpriteRenderer>().flipY = true;
                sprite4.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.black;
                Color tmp = sprite4.transform.GetChild(0).GetComponent<SpriteRenderer>().color;
                tmp.a = 0.5f;
                sprite4.transform.GetChild(0).GetComponent<SpriteRenderer>().color = tmp;
                sprite4.transform.GetChild(0).GetComponent<Animator>().enabled = false;
            }

            if (Game.roster[team1.playingCharacters[0]].health == 0 && Game.roster[team1.playingCharacters[1]].health == 0)
            {
                isPlaying = false;
            }
            if (Game.roster[team2.playingCharacters[0]].health == 0 && Game.roster[team2.playingCharacters[1]].health == 0)
            {
                isPlaying = false;
            }



            if (waitingForMoveInput)
            {
                moveInput = getInput();
            }

            if (waitingForTargetInput)
            {
                targetInput = getInput();
            }


            if (turn == 1)
            {
                if (!waitingForMoveInput && !waitingForTargetInput)
                    dialogText.text = " It's Player 1's turn!\n\n";
                    //Debug.Log(" It's the turn of player 1");
                if (indexCurrentChar == 0)
                {
                    if (!waitingForMoveInput && !waitingForTargetInput)
                        
                        if (dialogText.text != null)
                        {
                            string tampon = dialogText.text;
                            dialogText.text = tampon + "Enter Input for " + Game.roster[team1.playingCharacters[indexCurrentChar]].name + " in team 1 \n A - attack\n S - ultimate\n D - combo\n";
                        }
                        else
                            dialogText.text = "Enter Input for " + Game.roster[team1.playingCharacters[indexCurrentChar]].name + " in team 1 \n A - attack\n S - ultimate\n D - combo";
                        //Debug.Log("Enter Input for " + Game.roster[team1.playingCharacters[indexCurrentChar]].name + " in team 1 ( A - attack S - ultimate D - combo)");

                    waitingForMoveInput = true;
                    if (moveInput != "")
                    {
                        waitingForMoveInput = false;
                        Character currentCharacter = Game.roster[team1.playingCharacters[indexCurrentChar]];


                        applyMoveInput(team2, team1, currentCharacter, 1);

                        if (moveInput != "a" || !waitingForTargetInput)
                        {
                            // resets inputs for next play
                            moveInput = "";
                            targetInput = "";
                            indexCurrentChar = 1;
                        }

                    }
                    // the kid didnt give an input dont do anything

                }
                else
                {
                    if (!waitingForMoveInput && !waitingForTargetInput)
                         dialogText.text = "Enter Input for " + Game.roster[team1.playingCharacters[indexCurrentChar]].name + " in team 1 \n A - attack\n S - ultimate\n D - combo";
                       // Debug.Log("Enter Input for " + Game.roster[team1.playingCharacters[indexCurrentChar]].name + " in team 1 ( A - attack S - ultimate D - combo)");
                    waitingForMoveInput = true;
                    if (moveInput != "")
                    {
                        waitingForMoveInput = false;
                        Character currentCharacter = Game.roster[team1.playingCharacters[indexCurrentChar]];


                        applyMoveInput(team2, team1, currentCharacter, 0);

                        if (moveInput != "a" || !waitingForTargetInput)
                        {
                            // resets inputs for next play
                            moveInput = "";
                            targetInput = "";
                            indexCurrentChar = 0;
                            turn = 2;
                        }
                    }
                    // the kid didnt give an input dont do anything
                }

            }
            else
            {
                if (!waitingForMoveInput && !waitingForTargetInput)
                    dialogText.text = " It's the turn of player 2";
                    //Debug.Log(" It's the turn of player 2");
                if (indexCurrentChar == 0)
                {
                    if (!waitingForMoveInput && !waitingForTargetInput)
                            dialogText.text = "It's the turn of player 2 \n\nEnter Input for " + Game.roster[team2.playingCharacters[indexCurrentChar]].name + " in team 2 \n A - attack\n S - ultimate\n D - combo";
                        //Debug.Log("Enter Input for " + Game.roster[team2.playingCharacters[indexCurrentChar]].name + " in team 2 ( A - attack S - ultimate D - combo)");

                        waitingForMoveInput = true;
                    if (moveInput != "")
                    {
                        waitingForMoveInput = false;
                        Character currentCharacter = Game.roster[team2.playingCharacters[indexCurrentChar]];


                        applyMoveInput(team1, team2, currentCharacter, 1);

                        if (moveInput != "a" || !waitingForTargetInput)
                        {
                            // resets inputs for next play
                            moveInput = "";
                            targetInput = "";
                            indexCurrentChar = 1;
                        }

                    }
                    // the kid didnt give an input dont do anything

                }
                else
                {
                    if (!waitingForMoveInput && !waitingForTargetInput)
                        dialogText.text = "Enter Input for " + Game.roster[team2.playingCharacters[indexCurrentChar]].name + " in team 2 \n A - attack\n S - ultimate\n D - combo";

                    //Debug.Log("Enter Input for " + Game.roster[team2.playingCharacters[indexCurrentChar]].name + " in team 2 ( A - attack S - ultimate D - combo)");
                    waitingForMoveInput = true;
                    if (moveInput != "")
                    {
                        waitingForMoveInput = false;
                        Character currentCharacter = Game.roster[team2.playingCharacters[indexCurrentChar]];


                        applyMoveInput(team1, team2, currentCharacter, 0);

                        if (moveInput != "a" || !waitingForTargetInput)
                        {
                            // resets inputs for next play
                            moveInput = "";
                            targetInput = "";
                            indexCurrentChar = 0;
                            turn = 1;
                        }
                    }
                    // the kid didnt give an input dont do anything
                }
                // code to run the game
            }
        }
        else
        {
            
            foreach(Character c in Game.roster)
            {
                c.reset();
            }
            characterSelection.isDone = false;
            characterSelection.enabled = true;
            speech.SetActive(false);
            this.gameObject.SetActive(false);
            toggleAllAnimation(false);
            flipAllSprites(false);
            characterSelection.Start();
            characterSelection.initialiseAllHeroes();
            if(team1.playingCharacters != null)
                team1.playingCharacters.Clear();
            if(team2.playingCharacters != null)
                team2.playingCharacters.Clear();
            
        }
    }

    public void toggleAllAnimation(bool value)
    {
        sprite1.transform.GetChild(0).GetComponent<Animator>().enabled = value;
        sprite2.transform.GetChild(0).GetComponent<Animator>().enabled = value;
        sprite3.transform.GetChild(0).GetComponent<Animator>().enabled = value;
        sprite4.transform.GetChild(0).GetComponent<Animator>().enabled = value;

    }

    public void flipAllSprites(bool value)
    {
        sprite1.transform.GetChild(0).GetComponent<SpriteRenderer>().flipY = value;
        sprite2.transform.GetChild(0).GetComponent<SpriteRenderer>().flipY = value;
        sprite3.transform.GetChild(0).GetComponent<SpriteRenderer>().flipY = value;
        sprite4.transform.GetChild(0).GetComponent<SpriteRenderer>().flipY = value;

    }

    public void applyMoveInput(Team enemyTeam,Team gentilleTeam,Character currentCharacter,int indexTeamate)
    {
        if (moveInput == "a")
        {
            // normal attack 
            // we need a target 

            if (!waitingForTargetInput)
                dialogText.text = "Waiting for a target input ... \n\n Choose A on your keyboard to select the first ennemy or S for the second enemy";
               // Debug.Log("Waiting for a target input chose A (for the first) or S (for the second on your keyboard");
            waitingForTargetInput = true;

            if (targetInput != "")
            {

                waitingForTargetInput = false;

                List<Character> target = new List<Character>();
                if (targetInput == "a")
                {

                    // attack first enemy
                    target.Add(Game.roster[enemyTeam.playingCharacters[0]]);
                    currentCharacter.doAttack(target);


                    if (currentCharacter.name == "Curt") curt.Play();
                    if (currentCharacter.name == "Ellie") ellie.Play();
                    if (currentCharacter.name == "Joao") joao.Play();
                    if (currentCharacter.name == "Sydney") sydney.Play();
                    if (currentCharacter.name == "Taylor") taylor.Play();
                    if (currentCharacter.name == "Wess") wess.Play();
                }
                else
                {
                    target.Add(Game.roster[enemyTeam.playingCharacters[1]]);
                    currentCharacter.doAttack(target);
                    // attack second enemy

                    if (currentCharacter.name == "Curt") curt.Play();
                    if (currentCharacter.name == "Ellie") ellie.Play();
                    if (currentCharacter.name == "Joao") joao.Play();
                    if (currentCharacter.name == "Sydney") sydney.Play();
                    if (currentCharacter.name == "Taylor") taylor.Play();
                    if (currentCharacter.name == "Wess") wess.Play();
                }


            }
        }
        else if (moveInput == "s")
        {
            // ultimate attack
            List<int> teamate = new List<int>();
            teamate.Add(gentilleTeam.playingCharacters[indexTeamate]);
            currentCharacter.doUltimate(teamate, enemyTeam.playingCharacters);

            if (currentCharacter.name == "Curt") curtU.Play();
            if (currentCharacter.name == "Ellie") ellieU.Play();
            if (currentCharacter.name == "Joao") joaoU.Play();
            if (currentCharacter.name == "Sydney") sydneyU.Play();
            if (currentCharacter.name == "Taylor") taylorU.Play();
            if (currentCharacter.name == "Wess") wessU.Play();
        }
        else if (moveInput == "d")
        {
            // combo
            List<int> teamate = new List<int>();
            teamate.Add(gentilleTeam.playingCharacters[indexTeamate]);
            currentCharacter.doComboAttack(teamate, enemyTeam.playingCharacters);

            if (currentCharacter.name == "Curt") curtU.Play();
            if (currentCharacter.name == "Ellie") ellieU.Play();
            if (currentCharacter.name == "Joao") joaoU.Play();
            if (currentCharacter.name == "Sydney") sydneyU.Play();
            if (currentCharacter.name == "Taylor") taylorU.Play();
            if (currentCharacter.name == "Wess") wessU.Play();

        }
    }
    public string getInput()
    {
        string input = "";

        if (waitingForMoveInput)
        {
            if (Input.GetKeyDown(KeyCode.A)) //ATTACK
            {

                input = "a";
                dialogText.text = "Inputting a normal attack";
                //Debug.Log("Inputting a normal attack");
            }
            if (Input.GetKeyDown(KeyCode.D)) //DEFEND
            {
                dialogText.text = "doing the combo attack";

                //Debug.Log("doing the combo attack");
                input = "d";
                
            }
            if (Input.GetKeyDown(KeyCode.S)) //COMBO
            {
                dialogText.text = "Inputting the ultimate attack";
               // Debug.Log("Inputting the ultimate attack");
                input = "s";
            }
        }else if (waitingForTargetInput)
        {
            if (Input.GetKeyDown(KeyCode.A)) //ATTACK
            {

                input = "a";
                dialogText.text = "Chosing the first ennemy";
                // Debug.Log("Chosing the first ennemy");
            }
            if (Input.GetKeyDown(KeyCode.S)) //DEFEND
            {
                dialogText.text = "Choosing the second enemy";
                //Debug.Log("Choosing the second enemy");
                input = "s";

            }
        }


        return input;

    }
    
}



