using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{

    public List<Character> roster = new List<Character>();
    // stock les team
    public Team team1 = new Team();
    public Team team2 = new Team();
    public GameObject gameplayCamera;
    public GameObject charactSelectCamera;
    public CharacterSelection characterSelection;


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


        charactSelectCamera.GetComponent<Camera>().enabled = true;
        gameplayCamera.GetComponent<Camera>().enabled = false;
        charactSelectCamera.SetActive(true);
        gameplayCamera.SetActive(false);
       
    }

    // Update is called once per frame

    public void teamSelectionDone()
    {

        current = State.Gameplay;


    }
    void Update()
    {


        // hero select done change
        if (characterSelection.isDone) {
            changeMainCamera();
            current = State.Gameplay;
        }





    }
    public void changeMainCamera() {

        charactSelectCamera.GetComponent<Camera>().enabled = false;
        gameplayCamera.GetComponent<Camera>().enabled = true;
        charactSelectCamera.SetActive(false);
        gameplayCamera.SetActive(true);


    }

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







