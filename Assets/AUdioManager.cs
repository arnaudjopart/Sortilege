using UnityEngine;
using System.Collections;

public class AUdioManager : MonoBehaviour {

    static AUdioManager m_instance;
	// Use this for initialization

    void Awake()
    {
        if( m_instance )
        {

            print( " Instance alreayd on scene " );
            Destroy( gameObject );
            
        }else
        {
            GameObject audioManager = GameObject.Find( "AudioManagar" );
            if(audioManager){

                print( " new instanceinstance " );
                m_instance = audioManager.GetComponent<AUdioManager>();
                DontDestroyOnLoad( m_instance );
                Destroy( gameObject );

            }else
            {
                m_instance = this;
                DontDestroyOnLoad( m_instance );
                print( " take this" );
            }
        }
    }
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
