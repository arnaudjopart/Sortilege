using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Recipe : MonoBehaviour {

    public Image m_star;
    public Sprite m_emptyStar;
    public Sprite m_goldStar;
    public int m_indexInBook;

    //public ChallengeManager m_challengeManager;

	// Use this for initialization
	void Start () {
        if( m_indexInBook <= PlayerPrefs.GetInt( "PROGRESSION" ))
        {
            m_star.sprite = m_goldStar;
        }else
        {
            m_star.sprite = m_emptyStar;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
