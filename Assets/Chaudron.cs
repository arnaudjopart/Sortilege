using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Chaudron : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{

    public delegate void GameOverDelegate();
    public event GameOverDelegate GameOverEvent;

    public RecipeManager m_recipeManager;
    public ParticleSystem m_particle;
    public ParticleSystem m_fire;
    public ParticleSystem m_fire2;
    public ParticleSystem m_feuFollet;
    public AudioClip[] m_sounds;
    public ParticleSystem m_explosionEffect;
    // Use this for initialization
    void Start () {
        m_audio = GetComponent<AudioSource>();
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
                            m_explosionEffect.Play();
                            StopFire();
                            m_audio.PlayOneShot( m_sounds[ 2 ] );
                            GameOverEvent();
                            return;
                        }else
                        {


                            if( m_recipeManager.m_ingredientsArray[ (int)ingredient.m_typeOfIngredient ] == 0 )
                            {
                                print( "this ingredient is ok" );
                                ingredient.Highlight();
                                vessel.Empty( vessel.m_currentNumberOfFilledUnits );
                                m_feuFollet.Play();
                                
                                m_audio.PlayOneShot( m_sounds[ 0 ] );
                                return;
                            }else
                            {
                                print( "Add this ingredient" );
                                vessel.Empty( vessel.m_currentNumberOfFilledUnits );
                                m_feuFollet.Play();
                                m_audio.PlayOneShot( m_sounds[ 1 ] );
                                return;
                            }
                        }
                        //Destroy( vessel.gameObject );
                        
                    }else
                    {
                        
                    }
                }

                GameOverEvent();
                m_explosionEffect.Play();
                StopFire();
                vessel.Empty( vessel.m_currentNumberOfFilledUnits );
                m_audio.PlayOneShot( m_sounds[ 2 ] );
                print( "Not an ingredient from the recipe" );
                return;
                //Destroy( vessel.gameObject );
            }
        }
    }
    private void StopFire()
    {
        m_fire.Stop();
        m_fire2.Stop();
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

    private AudioSource m_audio;
}
