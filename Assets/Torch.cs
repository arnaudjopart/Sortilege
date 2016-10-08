using UnityEngine;
using System.Collections;

public class Torch : MonoBehaviour {

    // Use this for initialization
    void Awake()
    {
        m_light = GetComponent<Light>();
    }


    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    private Light m_light;
}
