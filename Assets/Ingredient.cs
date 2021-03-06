﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Ingredient : MonoBehaviour {

    public int m_quantity;
    public GameManager.CONTENTTYPE m_typeOfIngredient;
    public Text m_quantityText;
    public Sprite[] m_spritesArray;
    public Image m_image;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
                
      
        //m_ingredientText.text = m_typeOfIngredient.ToString();
        m_quantityText.text = "x " + m_quantity.ToString();
    }

    public void Load(int _index, int _nb)
    {
        m_typeOfIngredient = (GameManager.CONTENTTYPE)Enum.ToObject( typeof( GameManager.CONTENTTYPE ), _index );
        m_image.sprite = m_spritesArray[ _index ];
        m_quantity = _nb;

        

    }
    public void Highlight()
    {
        
        m_quantityText.color = Color.green;
    }
}
