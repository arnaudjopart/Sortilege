using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Vessel : MonoBehaviour {

    public Color m_starColor;
    public int m_totalNumberOfUnits;
    public int m_currentNumberOfFilledUnits;
    public GameObject m_unitPrefab;

    public enum STATE { EMPTY, FILL, FULL};
    public STATE m_currentState = STATE.EMPTY;
    public GameManager.CONTENTTYPE m_currentType;
    public List<Unit> m_listOfUnits = new List<Unit>();
    public bool m_isUsed;

    // Use this for initialization
    #region Main Methods
    void Awake()
    {
        m_transform = GetComponent<Transform>();
        Init();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch( m_currentState )
        {
            case STATE.EMPTY:
                break;
            case STATE.FILL:
                break;
            case STATE.FULL:
                
                break;
            default:
                break;
        }
    }

    public void Fill(int _nbUnit, Color _color, GameManager.CONTENTTYPE _elementType)
    {
        m_isUsed = true;

        for(int i =0; i< Mathf.Min( _nbUnit, m_totalNumberOfUnits );i++ )
        {
            m_listOfUnits[ i].SetColor( _color );
        }
        m_currentState = STATE.FILL;
        m_currentNumberOfFilledUnits += _nbUnit;

        if(_nbUnit == m_totalNumberOfUnits )
        {
            m_currentState = STATE.FULL;
            m_currentNumberOfFilledUnits = m_totalNumberOfUnits;
        }
        m_currentType = _elementType;
        
    }

    public void Empty(int _nbUnit)
    {
        for( int i =0;i< Mathf.Min( _nbUnit, m_totalNumberOfUnits ); i++ )
        {
            m_listOfUnits[ i ].SetColor( m_starColor );
        }

        m_currentState = STATE.FILL;
        m_currentNumberOfFilledUnits -= _nbUnit; 

        if( _nbUnit == m_totalNumberOfUnits )
        {
            m_currentState = STATE.EMPTY;
            m_currentNumberOfFilledUnits = 0;
            m_currentType = GameManager.CONTENTTYPE.NONE;
            Destroy( gameObject );
            
        }
        
        
    }
    #endregion


    #region Utils
    void Init()
    {
        m_currentType = GameManager.CONTENTTYPE.NONE;
        for( int i = 0; i < m_totalNumberOfUnits; i++ )
        {
            GameObject item = Instantiate(m_unitPrefab,Vector3.zero,Quaternion.identity) as GameObject;
            Unit unit = item.GetComponent<Unit>();
            unit.SetColor( m_starColor );
            item.transform.SetParent( m_transform, false );
            m_listOfUnits.Add( unit );
        }
    }
    #endregion



    #region Private Members

    private Transform m_transform;

    #endregion
}
