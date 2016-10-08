using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Chaudron : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{

    public delegate void GameOverDelegate();
    public event GameOverDelegate GameOverEvent;

    public RecipeManager m_recipeManager;
    public ParticleSystem m_particle;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void OnDrop(PointerEventData eventData)
    {
        if( eventData.pointerDrag.GetComponent<Vessel>() )
        {
            Vessel vessel = eventData.pointerDrag.GetComponent<Vessel>();
            if( vessel != null )
                
            {
                foreach(Ingredient ingredient in m_recipeManager.m_ingredientList )
                {
                    if(ingredient.m_typeOfIngredient == vessel.m_currentType )
                    {
                        print( "Chaudron" );
                        m_recipeManager.m_ingredientsArray[ (int)ingredient.m_typeOfIngredient ] -= vessel.m_currentNumberOfFilledUnits;
                        ingredient.m_quantity = m_recipeManager.m_ingredientsArray[ (int)ingredient.m_typeOfIngredient ];
                        if( m_recipeManager.m_ingredientsArray[ (int)ingredient.m_typeOfIngredient ] < 0 )
                        {
                            print( "Too many ingredients" );
                            GameOverEvent();
                            return;
                        }else
                        {
                            if( m_recipeManager.m_ingredientsArray[ (int)ingredient.m_typeOfIngredient ] == 0 )
                            {
                                print( "this ingredient is ok" );
                                ingredient.Highlight();
                                vessel.Empty( vessel.m_currentNumberOfFilledUnits );
                                return;
                            }else
                            {
                                print( "Add this ingredient" );
                                vessel.Empty( vessel.m_currentNumberOfFilledUnits );
                                return;
                            }
                        }
                        //Destroy( vessel.gameObject );
                        
                    }else
                    {
                        GameOverEvent();
                        print( "Not an ingredient from the recipe" );
                    }
                }
                //Destroy( vessel.gameObject );
            }
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }
    public void OnPointerExit(PointerEventData eventData)
    {

    }
    public void LaunchParticle()
    {
        m_particle.Play();
    }
}
