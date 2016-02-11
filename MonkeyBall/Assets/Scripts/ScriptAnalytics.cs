using UnityEngine;
using System.Collections;

public class ScriptAnalytics : MonoBehaviour {

    
    private static bool created = false;
    // Use this for initialization

    public int currentTimeAmount;

	void Awake ()
    {
        if (!created)
        {
            DontDestroyOnLoad(transform.gameObject);
            created = true;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if(PlayerPrefs.GetString("PlayedBefore") != "yes")
        {
            PlayerPrefs.SetInt("LevelOne", 0);
            PlayerPrefs.SetInt("LevelTwo", 0);
            PlayerPrefs.SetInt("LevelThree", 0);
            PlayerPrefs.SetInt("LevelFour", 0);
            PlayerPrefs.SetInt("LevelFive", 0);

            Debug.Log("First Time Playing!");
            PlayerPrefs.SetString("PlayedBefore", "yes");
        }
        else
        {
            Debug.Log("You've played before! Yay.");

        }
    }
	
	/// <summary>
    /// Start the timer for how long the level is being played for.
    /// </summary>
	void OnLevelWasLoaded()
    {
        Debug.Log(Application.loadedLevelName);
    }

    public void LevelTime(float pTime)
    {
        string lvlName = Application.loadedLevelName;

        int timesPlayed = PlayerPrefs.GetInt(lvlName + "timesPlayed");
        PlayerPrefs.SetInt(lvlName + "timesPlayed", timesPlayed + 1);

        float totalTime = PlayerPrefs.GetFloat(lvlName + "totaledTime");
        PlayerPrefs.SetFloat(lvlName + "totaledTime", totalTime + pTime);
        if(timesPlayed > 1)
            PlayerPrefs.SetFloat(lvlName + "averageTime", totalTime / timesPlayed);
        
        float fastestTime = 0;
        fastestTime = PlayerPrefs.GetFloat(lvlName + "fastestTime");
        if(fastestTime == 0)
        {
            PlayerPrefs.SetFloat(lvlName + "fastestTime", pTime);
        }
        else if(pTime < fastestTime)
        {
            PlayerPrefs.SetFloat(lvlName + "fastestTime", pTime);
        }

    }

    /// <summary>
    /// Sets the player prefs value of the level name + complete to 1.
    /// </summary>
    /// <param name="lvlName"></param>
    public void SetLevelComplete(string lvlName)
    {
        PlayerPrefs.SetInt(lvlName, 1);
    }

    public int GetValue(string lvlName)
    {
        return PlayerPrefs.GetInt(lvlName);
    }
}
