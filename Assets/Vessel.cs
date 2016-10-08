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

    }

    public void Fill(int _nbUnit, Color _color, GameManager.CONTENTTYPE _elementType)
    {
        for(int i = 0; i < Mathf.Min( _nbUnit,m_totalNumberOfUnits);i++ )
        {
            m_listOfUnits[ i].SetColor( _color );
        }
        m_currentState = STATE.FILL;

        if(_nbUnit == m_totalNumberOfUnits )
        {
            m_currentState = STATE.FULL;
        }
        m_currentType = _elementType;
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
