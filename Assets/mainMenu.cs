using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour {

	// Use this for initialization

     
	void Start () {
        m_audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void GotONextScene()
    {
        Invoke( "LoadNextScene", .5f );
        m_audio.Play();

    } 

    void LoadNextScene()
    {
        SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex+1 );
    }

    public void QuitGame()
    {
        Application.Quit();
    }
   private AudioSource m_audio;


}



