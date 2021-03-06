﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Reserve : MonoBehaviour {

    public Color m_colorOfItem;
    public int m_nbOfUnits;
    public int m_currentNbOfUnits;

    public GameObject m_itemPrefab;

    public GameManager.CONTENTTYPE m_currentContent;
    public List<GameObject> m_listOfUnits = new List<GameObject>();

	// Use this for initialization

    void Awake()
    {
        m_transform = GetComponent<Transform>();
        
    }
	void Start () {
        //Init();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void Init(int _nbOfUnits)
    {
        m_nbOfUnits = _nbOfUnits;
        m_currentNbOfUnits = _nbOfUnits;

        for(int i = 0; i < _nbOfUnits; i++ )    
        {
            GameObject item = Instantiate(m_itemPrefab,Vector3.zero,Quaternion.identity) as GameObject;
            item.GetComponent<Unit>().SetColor( m_colorOfItem );
            item.transform.SetParent( m_transform, false );
            m_listOfUnits.Add( item );
        }
    }

    public void Empty(int _nb)
    {
        
        for(int i =0;i<Mathf.Min(m_currentNbOfUnits,_nb);i++ )
        {
            print( "empty reserve" );
            Destroy( m_listOfUnits[ 0]);
            m_listOfUnits.RemoveAt( 0 );
        }
        m_currentNbOfUnits -= _nb;
        m_currentNbOfUnits = Mathf.Max( m_currentNbOfUnits, 0 );
    }
    public void Fill(int _nbUnits)
    {
        for( int i = 0; i <  _nbUnits; i++ )
        {
            GameObject item = Instantiate(m_itemPrefab,Vector3.zero,Quaternion.identity) as GameObject;
            item.GetComponent<Unit>().SetColor( m_colorOfItem );
            item.transform.SetParent( m_transform, false );
            m_listOfUnits.Add( item );
        }
    }
    public void Reset()
    {
        foreach(Transform obj in transform )
        {
            Destroy( obj.gameObject );
            m_listOfUnits.Clear();
        }
    }

    #region Private Elements
    Transform m_transform;
    #endregion
}
