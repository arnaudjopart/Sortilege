using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Unit : MonoBehaviour {

    // Use this for initialization
    void Awake()
    {
        m_image = GetComponent<Image>();
    }

    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetColor(Color _color)
    {
        m_image.color = _color;
    }

    #region Private Members
    private Image m_image;
    #endregion
}
