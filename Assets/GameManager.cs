using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    public string[] m_ElementsNameArray;
    public Color[] m_ElementsColorArray;
    public int m_currentChallenge;
    public enum CONTENTTYPE { A = 0, B = 1, C = 2, D = 3, E = 4, F = 5, G = 6, H = 7,NONE = 8 };
    public enum STATE {INTRO = 0, PLAYING = 1,WIN=2,LOOSE=3 };
    public STATE m_currentState = STATE.PLAYING;

    public static List<Challenge> m_challengesList = new List<Challenge>(); 
    public RecipeManager m_recipeManager;
    public Reserve[] m_reservesArray;
    public VesselManager m_vesselManager;

    
    public Chaudron m_chaudron; 

    // Use this for initialization
    void Start () {
        m_chaudron.GameOverEvent += GameOver;
        m_challengesList.Add( Challenge.CreateChallenge( 2, 3, 0, new int[] {2,1}, new int[] { 2, 0, 0 },1  ));
        m_challengesList.Add( Challenge.CreateChallenge( 2, 2, 2, new int[] { 1, 1, 1, 1 }, new int[] { 2, 0, 0 },2 ) );
        m_challengesList.Add( Challenge.CreateChallenge( 6, 0, 0, new int[] { 5, 2, 2, 1 }, new int[] { 3, 0, 0 },3 ) );
        m_challengesList.Add( Challenge.CreateChallenge( 8, 0, 0, new int[] { 5, 2, 3, 1 ,1,1}, new int[] { 7, 0, 0 } ,3) );
        m_challengesList.Add( Challenge.CreateChallenge( 2, 1, 0, new int[] { 2, 1, 2, 1 }, new int[] { 2, 1, 0 },5 ) );
        m_challengesList.Add( Challenge.CreateChallenge( 5, 5, 0, new int[] { 3, 1, 5, 1, 1, 1, 2, 1 }, new int[] { 4, 3, 0 } ,5) );
        m_challengesList.Add( Challenge.CreateChallenge( 5, 3, 0, new int[] { 2, 1, 4, 1, 2, 1, 2, 1 }, new int[] { 4, 0, 0 } ,5) );
        m_challengesList.Add( Challenge.CreateChallenge( 3, 7, 0, new int[] { 2, 1, 2, 1, 2, 1 }, new int[] { 1, 5, 0 },5 ) );
        m_challengesList.Add( Challenge.CreateChallenge( 8, 8, 5, new int[] { 5, 2, 3, 2, 2, 3,2, 1 }, new int[] { 1, 6, 4 } ,5) );
        m_challengesList.Add( Challenge.CreateChallenge( 5, 8, 3, new int[] { 5, 1, 3, 1, 2, 1, 2, 1 }, new int[] { 1, 6, 4 } ,5) );
        LoadLevel( m_currentChallenge );
    }
	
	// Update is called once per frame
	void Update () {
        switch( m_currentState )
        {
            case STATE.INTRO:
                break;
            case STATE.PLAYING:
                break;
            case STATE.WIN:
                print( "waiting" );
                if( Time.time > m_startTimer + 3 )
                {
                    m_currentState = STATE.PLAYING;
                    Refresh();
                }
                break;
            case STATE.LOOSE:
                break;
            default:
                break;
        }
    }
    public void GameOver()
    {
        print( "GameOver" );
        m_currentState = STATE.LOOSE;
    }
    public void Win()
    {
        print( "Win" );
        m_currentState = STATE.WIN;
        m_startTimer = Time.time;

    }
    private void LoadLevel(int _index)
    {
        m_reservesArray[ 0 ].Init( m_challengesList[ _index ].GetRedUnits());
        m_reservesArray[ 1 ].Init( m_challengesList[ _index ].GetGreenUnits() );
        m_reservesArray[ 2 ].Init( m_challengesList[ _index ].GetBlueUnits() );

        m_vesselManager.LoadVessels( m_challengesList[_index ].GetListOfVessel() );
        m_recipeManager.LoadRecipe( m_challengesList[ _index ].GetRecipe() );
    }
    public void Refresh()
    {
        print( "refresh" );
        m_reservesArray[ 0 ].Reset();
        m_reservesArray[ 1 ].Reset();
        m_reservesArray[ 2 ].Reset();

        m_vesselManager.ClearVessels();
        m_recipeManager.ClearRecipe();
        m_currentChallenge += 1;
        LoadLevel( m_currentChallenge );
    }
    public void Reset()
    {
        print( "reset" );
        m_reservesArray[ 0 ].Reset();
        m_reservesArray[ 1 ].Reset();
        m_reservesArray[ 2 ].Reset();

        m_vesselManager.ClearVessels();
        m_recipeManager.ClearRecipe();
        
        LoadLevel( m_currentChallenge );
    }
    private float m_startTimer;
}
