using UnityEngine;
using System.Collections;

public class VesselManager : MonoBehaviour {


    public GameObject m_vesselPrefab;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void LoadVessels(int[] _array)
    {
        print( _array.Length );
        for(int i =0;i<_array.Length; i+=2 )
        {
            GameObject vessel = Instantiate(m_vesselPrefab,Vector3.zero, Quaternion.identity) as GameObject;
            vessel.transform.SetParent( transform, false );
            
            vessel.GetComponent<Vessel>().Init( _array[i], _array[ i+ 1 ]);
        }

        
    }
    public void ClearVessels()
    {
        foreach(RectTransform obj in transform )
        {
            Destroy( obj.gameObject );
        }
    }
}
