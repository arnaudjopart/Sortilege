﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler,IDragHandler,IEndDragHandler {

    // Use this for initialization

    void Awake()
    {
        m_transform = GetComponent<Transform>();
        
        m_canvasGroup = GetComponent<CanvasGroup>();
    }

    void Start () {
        m_startPosition = transform.position;
        m_parent = m_transform.parent;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnBeginDrag(PointerEventData eventData)
    {
        print( "OnBeginDrag" );
        Invoke( "ChangeParent", .3f );

        
        m_canvasGroup.blocksRaycasts = false;
        

    }
    public void OnDrag(PointerEventData eventData)
    {
        print( "OnDrag" );
        transform.position = eventData.position;

    }
    public void OnEndDrag(PointerEventData eventData)
    {
        print( "OnEndDrag" );
        Invoke( "StopDrag", .1f );
        //transform.position = m_startPosition;
       
    }

    private void ChangeParent()
    {
        m_transform.SetParent( transform.parent.parent, false );
    }

    private void StopDrag()
    {
        m_transform.SetParent( m_parent, false );
        m_canvasGroup.blocksRaycasts = true;
    }
    #region Private Members
    private Vector3 m_startPosition;
    private Transform m_transform;
    private Transform m_parent;
    private CanvasGroup m_canvasGroup;
    #endregion
}
