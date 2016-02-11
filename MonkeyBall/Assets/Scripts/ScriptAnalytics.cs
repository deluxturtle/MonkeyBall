using UnityEngine;
using System.Collections;

public class ScriptAnalytics : MonoBehaviour {

    //for completion    0 = incompleted lvl
    //                  1 = completed lvl
    private static bool created = false;
    // Use this for initialization

    public float startTime;
    public float endTime;

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
        startTime = Time.deltaTime;
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
