using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RecipeManager : MonoBehaviour {

    public List<Ingredient> m_ingredientList = new List<Ingredient>();
    public int[] m_ingredientsArray;
    public GameObject ingredientsPrefab;

	// Use this for initialization
	void Start () {
        LoadRecipe();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadRecipe()
    {
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
    }
}
