using UnityEngine;
using System.Collections;

public class ScriptChangeScene : MonoBehaviour {

	public void _MainMenu()
    {
        Application.LoadLevel("MainMenu");
    }

    public void _Store()
    {
        Application.LoadLevel("Store");
    }

    public void _SelectLevel()
    {
        Application.LoadLevel("LevelSelect");
    }

    public void _LevelOne()
    {
        Application.LoadLevel("LevelOne");
    }

    public void _LevelTwo()
    {
        Application.LoadLevel("LevelTwo");
    }

    public void _LevelThree()
    {
        Application.LoadLevel("LevelThree");
    }

    public void _LevelFour()
    {
        Application.LoadLevel("LevelFour");
    }

    public void _LevelFive()
    {
        Application.LoadLevel("LevelFive");
    }

    public void _Quit()
    {
        Application.Quit();
    }

    public void _NextLevel()
    {
        switch (Application.loadedLevelName)
        {
            case "LevelOne":
                Application.LoadLevel("LevelTwo");
                break;
            case "LevelTwo":
                Application.LoadLevel("LevelThree");
                break;
            case "LevelThree":
                Application.LoadLevel("LevelFour");
                break;
            case "LevelFour":
                Application.LoadLevel("LevelFive");
                break;
            case "LevelFive":
                Application.LoadLevel("MainMenu");
                break;

        }
    }
}
