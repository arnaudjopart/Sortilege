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

                switch( vessel.m_currentState )
                {
                    case Vessel.STATE.EMPTY:

                        vessel.Fill( Mathf.Min( m_reserve.m_nbOfUnits, vessel.m_totalNumberOfUnits ), m_reserve.m_colorOfItem, m_reserve.m_currentContent );
                        m_reserve.Empty( vessel.m_totalNumberOfUnits );

                        break;
                    case Vessel.STATE.FILL:
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
