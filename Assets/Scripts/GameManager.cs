﻿using UnityEngine;

public class GameManager : MonoBehaviour
{


    public GameState State = GameState.META_PAUSED;
    public bool IsRunning = false;
    public int MinuteOfPlay = 0;

    private PitchManager pitchManager;
    private Ball ball;
    private Team teamA;
    private Team teamB;
    public static GameManager instance;              //Static instance of GameManager which allows it to be accessed by any other script.


    // TEMP
    public GameObject middleLine;
    public GameObject player1;
    public GameObject player2;

    private PositionCalculator positionCalculator;


    // Use this for initialization
    void Awake()
    {
        //if not, set instance to this
        if (instance == null)
        {
            instance = this;
        }
        //If instance already exists and it's not this:
        else if (instance != this)
        {
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        }


        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        pitchManager = GetComponent<PitchManager>();
        InitGame();
    }

    private void InitGame()
    {
        pitchManager.SetupPitch();

        SetupTeams();


        //START MATCH
        PlayMatch();

    }

    private void PlayMatch()
    {
        //throw new NotImplementedException();
        //positionCalculator = new PositionCalculator(pitchManager);
    }

    private void SetupTeams()
    {
        // 0 = home, 1 away?
        teamA = new Team("TEAM A", 0, new Tactic442());
        teamB = new Team("TEAM B", 1, new Tactic442());

        teamCreated = true;
        // Should draw all players on screen
    }

    private void SetupBall()
    {
        ball = new Ball();
    }

    // Update is called once per frame

    private bool initialized = false;
    bool teamCreated = false;
    //private GameObject a;
    void Update()
    {
        if (!initialized && teamCreated)
        {
            foreach (var playerPos in teamA.Tactic.TeamFormationPlayers)
            {
                var value = playerPos.Value;
                //Player goalkeeper = teamA.PlayersInGame[0];
                //var a = Instantiate(playerPos.Value.sprite, value.CurrentPosition, Quaternion.identity) as GameObject;
                var a = Instantiate(middleLine, value.CurrentPosition, Quaternion.identity) as GameObject;

            }
            initialized = true;

        }

        //if (teamA != null && gk == false)
        //{
        //    if (teamA.PlayersInGame.Count > 0)
        //    {
        //        Player goalkeeper = teamA.PlayersInGame[0];
        //        a = Instantiate(middleLine, new Vector2(goalkeeper.CurrentPosition.x, goalkeeper.CurrentPosition.y), Quaternion.identity) as GameObject;
        //        gk = true;

        //        a.transform.position = new Vector2(a.transform.position.x + 5, a.transform.position.y);

        //    }
        //}

    }

    //TEMP
    void MovePlayer(GameObject a)
    {
        //if (gk)
        //{
        //    a.transform.position = new Vector2(a.transform.position.x + 5, a.transform.position.y);
        //}
    }










    public bool IsPreperation()
    {
        return State != GameState.META_PAUSED && State != GameState.PLAY;
    }
    public bool IsPlay()
    {
        return State == GameState.PLAY;
    }
}
