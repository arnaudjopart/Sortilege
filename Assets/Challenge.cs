using UnityEngine;
using System.Collections;

public class Challenge {


	public Challenge(int[] _vessels, int red,int green,int blue,int[] _recipe,int _devScore)
    {
        Debug.Log( "challenge created" );
        m_vesselsArray = _vessels;
        m_nbRed = red;
        m_nbOfGreen = green;
        m_nbOfBlue = blue;
        m_recipe = _recipe;
        m_devScore = _devScore;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="_id"></param>
    /// <param name="stars"></param>
    /// <param name="_nbOfRed"></param>
    /// <param name="_nbOfGreen"></param>
    /// <param name="_nbOfBlue"></param>
    /// <param name="_vessels"></param>
    /// <param name="_recipe"></param>
    /// <returns></returns>
    public static Challenge CreateChallenge(int _nbOfRed, int _nbOfGreen, int _nbOfBlue, int[] _vessels,int[] _recipe,int _devScore)
    {
        return new Challenge( _vessels, _nbOfRed, _nbOfGreen, _nbOfBlue,_recipe, _devScore );
        
    }

    public int[] GetListOfVessel()
    {
        return m_vesselsArray;
    }
    public int GetRedUnits()
    {
        return m_nbRed;
    }
    public int GetGreenUnits()
    {
        return m_nbOfGreen;
    }
    public int GetBlueUnits()
    {
        return m_nbOfBlue;
    }
    public int[] GetRecipe()
    {
        return m_recipe;
    }
    private int[] m_vesselsArray;
    private int m_nbRed,m_nbOfGreen, m_nbOfBlue;
    private int[] m_recipe;
    private int m_devScore;
}
