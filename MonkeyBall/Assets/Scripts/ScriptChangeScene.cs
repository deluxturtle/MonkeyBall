using UnityEngine;
using System.Collections;

public class ScriptChangeScene : MonoBehaviour {

	public void _MainMenu()
    {
        Application.LoadLevel("MainMenu");
    }

    public void _SelectLevel()
    {
        Application.LoadLevel("LevelSelect");
    }

    public void _LevelOne()
    {
        Application.LoadLevel("LevelOne");
    }
}
