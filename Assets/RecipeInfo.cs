using UnityEngine;
using System.Collections;

[System.Serializable]

public class RecipeInfo
{
    public string m_name;
    public int m_index;
    public string m_job;

    public RecipeInfo(int _index, string _name, string _job)
    {
        m_name = _name;
        m_index = _index;
        m_job = _job;
    }

    public string TransformInString()
    {
        return JsonUtility.ToJson( this );
    }
    public static RecipeInfo CreateFromJSON(string _jsonString)
    {
        return JsonUtility.FromJson<RecipeInfo>( _jsonString );
    }
    public void PrintInfo()
    {
        Debug.Log( m_index + " " + m_name + " " + m_job );
    }

}
