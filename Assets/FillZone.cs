using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class FillZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {

    // Use this for initialization
    void Awake()
    {
        m_reserve = GetComponent<Reserve>();
    }

    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void OnDrop(PointerEventData eventData)
    {

    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if( eventData !=null )
        {
            if( eventData.pointerDrag.GetComponent<Vessel>() != null )
            {
                Vessel vessel = eventData.pointerDrag.GetComponent<Vessel>();
                print( "vessel found" );
                switch( vessel.m_currentState )
                {
                    case Vessel.STATE.EMPTY:

                        vessel.Fill( Mathf.Min( m_reserve.m_currentNbOfUnits, vessel.m_totalNumberOfUnits ), m_reserve.m_colorOfItem, m_reserve.m_currentContent );
                        m_reserve.Empty( Mathf.Min( m_reserve.m_currentNbOfUnits, vessel.m_totalNumberOfUnits ) );

                        break;
                    case Vessel.STATE.FILL:
                        if( vessel.m_currentType == m_reserve.m_currentContent )
                        {
                            int delta = Mathf.Min(m_reserve.m_currentNbOfUnits,vessel.m_totalNumberOfUnits- vessel.m_currentNumberOfFilledUnits);
                            vessel.Fill( vessel.m_currentNumberOfFilledUnits+ delta, m_reserve.m_colorOfItem, m_reserve.m_currentContent );
                            m_reserve.Empty( delta );
                        }
                        
                        break;
                    case Vessel.STATE.FULL:

                        break;
                    default:
                        break;
                }



            }
        }
        


        Debug.Log( "OnPointerEnter" );
        
        

    }
    public void OnPointerExit(PointerEventData eventData)
    {

    }

    #region Private variables

    private Reserve m_reserve;

    #endregion

}
