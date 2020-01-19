using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{

    public static  List<Character> roster = new List<Character>();
    // stock les team
    public Team team1 = new Team();
    public Team team2 = new Team();
    //public GameObject gameplayCamera;
    //public GameObject charactSelectCamera;
    public CharacterSelection characterSelection;
    public Gameplay gamePlay;

    public GameObject selectionGrid;
    public GameObject Canvas;

    public Text dialog;


    public AudioSource fight;
    public AudioSource title;

    public bool fightIsPlaying = false;
    

    public int value = 0;

    enum State { Select, Gameplay };

    State current = State.Select;

    //team 1, team2
    int index = 1;


    // Start is called before the first frame update
    void Start()
    {
        // load characters
        loadCharacters();

    }

    // Update is called once per frame

    void Update()
    {


        // hero select done change
        if (characterSelection.isDone) {
            
            if (!fightIsPlaying)
            {
                fightIsPlaying = true;
                fight.Play();
                title.Stop();
            }

            current = State.Gameplay;
            selectionGrid.SetActive(false);
            Canvas.SetActive(false);
        }
        else
        {
            if (fightIsPlaying)
            {
                fightIsPlaying = false;
                title.Play();
                fight.Stop();
            }
            current = State.Select;
            selectionGrid.SetActive(true);
            Canvas.SetActive(true);
        }





    }
    /*
    public void changeMainCamera() {

        charactSelectCamera.GetComponent<Camera>().enabled = false;
        gameplayCamera.GetComponent<Camera>().enabled = true;
        charactSelectCamera.SetActive(false);
        gameplayCamera.SetActive(true);


    }
    */

    public void loadCharacters()
    {
        roster.Add(new Curt());

        roster.Add(new Sydney());

        roster.Add(new Ellie());

        roster.Add(new Wess());

        roster.Add(new Joao());

        roster.Add(new Taylor());
    }
}







