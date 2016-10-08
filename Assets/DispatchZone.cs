using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DispatchZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{

    // Use this for initialization
    void Awake()
    {
        m_vessel = GetComponent<Vessel>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnDrop(PointerEventData eventData)
    {
        print( eventData.pointerDrag.name );
       

        if( eventData != null )
        {
            if( eventData.pointerDrag.GetComponent<Vessel>() != null )
            {
                Vessel draggedVessel = eventData.pointerDrag.GetComponent<Vessel>();
                int availableUnits = m_vessel.m_totalNumberOfUnits-m_vessel.m_currentNumberOfFilledUnits;
                int delta;
                switch( draggedVessel.m_currentState )
                {
                    case Vessel.STATE.EMPTY:



                        break;
                    case Vessel.STATE.FILL:
                        
                        delta = Mathf.Min( availableUnits, draggedVessel.m_currentNumberOfFilledUnits );
                        m_vessel.Fill( m_vessel.m_currentNumberOfFilledUnits + delta, Color.black, draggedVessel.m_currentType );
                        draggedVessel.Empty( delta );
                        break;

                    case Vessel.STATE.FULL:
                        
                        delta = Mathf.Min( availableUnits, draggedVessel.m_currentNumberOfFilledUnits );
                        m_vessel.Fill( m_vessel.m_currentNumberOfFilledUnits+delta, Color.black, draggedVessel.m_currentType );
                        draggedVessel.Empty( delta );



                        break;
                    default:
                        break;
                }



            }
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        



        Debug.Log( "OnPointerEnter" );



    }
    public void OnPointerExit(PointerEventData eventData)
    {

    }

    #region Private variables

    private Vessel m_vessel;

    #endregion

}
