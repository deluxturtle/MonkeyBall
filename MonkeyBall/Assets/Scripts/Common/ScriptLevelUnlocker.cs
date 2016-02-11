using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

/// <summary>
/// @Author: Andrew Seba
/// @Description: Reads in the analytics player pref data, to unlock the levels if
/// the previous one has been completed.
/// </summary>
public class ScriptLevelUnlocker : MonoBehaviour {

    ScriptAnalytics analytic;

    [Tooltip("Place the level select button for level 1 here.")]
    public Button btnLevelOne;
    [Tooltip("Place the level select button for level 2 here.")]
    public Button btnLevelTwo;
    [Tooltip("Place the level select button for level 3 here.")]
    public Button btnLevelThree;
    [Tooltip("Place the level select button for level 4 here.")]
    public Button btnLevelFour;
    [Tooltip("Place the level select button for level 5 here.")]
    public Button btnLevelFive;

	// Use this for initialization
	void Start ()
    {
        Dictionary<string, Button> dictLevels = new Dictionary<string, Button>();
        dictLevels.Add("LevelOne", btnLevelOne);
        dictLevels.Add("LevelTwo", btnLevelTwo);
        dictLevels.Add("LevelThree", btnLevelThree);
        dictLevels.Add("LevelFour", btnLevelFour);
        dictLevels.Add("LevelFive", btnLevelFive);

        analytic = GameObject.Find("Analytic").GetComponent<ScriptAnalytics>();

        List<string> lvlNames = new List<string>();
        lvlNames.Add("LevelOne");
        lvlNames.Add("LevelTwo");
        lvlNames.Add("LevelThree");
        lvlNames.Add("LevelFour");
        lvlNames.Add("LevelFive");
        
        foreach(string lvlName in dictLevels.Keys)
        {
            if (analytic.GetValue(lvlName) == 1)
            {
                dictLevels[lvlName].interactable = true;
            }
        }
	}
}
