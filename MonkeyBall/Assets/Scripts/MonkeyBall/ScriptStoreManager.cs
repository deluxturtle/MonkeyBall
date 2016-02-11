using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// @Author: Andrew Seba
/// @Description: Populates the banana currency indicator.
/// </summary>
public class ScriptStoreManager : MonoBehaviour {

    public Text BananaAmount;

	// Use this for initialization
	void Start () {
        BananaAmount.text = PlayerPrefs.GetInt("Bananas").ToString();
	}
}
