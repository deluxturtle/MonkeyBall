using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScriptAddBanana : MonoBehaviour {

    int bananas = 0;
    public Text bananaCount;

	public void IncreaseBanana()
    {
        bananas++;
        bananaCount.text = bananas.ToString();
    }
}
