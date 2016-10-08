using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class RecipeManager : MonoBehaviour {

    public List<Ingredient> m_ingredientList = new List<Ingredient>();
    public int[] m_ingredientsArray;
    public GameObject ingredientsPrefab;
    public GameManager m_gameManager;
    public Chaudron m_chaudron;

	// Use this for initialization
	void Start () {
        //LoadRecipe();
	}
	
	// Update is called once per frame
	void Update () {

        foreach(int ingredientNeed in m_ingredientsArray )
        {
            if( ingredientNeed > 0 || ingredientNeed < 0 )
            {
                return;
            }
            
        }
        if( m_gameManager.m_currentState!=GameManager.STATE.WIN )
        {
            m_gameManager.Win();
            m_chaudron.LaunchParticle();
            
        }       

	}

    public void LoadRecipe(int[] _ingredientsArray)
    {
        m_ingredientsArray = _ingredientsArray;

        for(int i = 0; i< m_ingredientsArray.Length; i++ )
        {
            if( m_ingredientsArray[i] > 0 )
            {
                AddNewIngredient(i, m_ingredientsArray[ i ] );
            }
        }

        
    }

    private void AddNewIngredient(int _indexOfIngredient, int _quantity)
    {
        GameObject instance = Instantiate(ingredientsPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        instance.transform.SetParent( transform, false );
        Ingredient ingredient = instance.GetComponent<Ingredient>();
        ingredient.Load( _indexOfIngredient, _quantity );
        m_ingredientList.Add( ingredient );
    }

    public void ClearRecipe()
    {
        m_ingredientList.Clear();
        foreach( Transform obj in transform )
        {
            Destroy( obj.gameObject );
        }
    }
}
