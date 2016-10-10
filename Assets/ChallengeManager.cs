using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class ChallengeManager : MonoBehaviour {

    public static int CHALLENGETOLOAD;
    public static int PROGRESSION =5;

    private static ChallengeManager m_instance;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void LoadChallenge(int _index)
    {
        if( _index <= PlayerPrefs.GetInt( "PROGRESSION" ) ){
            print( "Load Challenge n° " + _index );
            Invoke( "LoadSelectedChallenge", .5f );
            CHALLENGETOLOAD = _index;
            print( "Load motherfucker" )
;        }
       
    }

    private void LoadSelectedChallenge()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene( currentScene + 1 );
    }
}
