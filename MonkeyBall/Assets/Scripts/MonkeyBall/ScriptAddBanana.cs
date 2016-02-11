using UnityEngine;
using UnityEngine.UI;

public class ScriptAddBanana : MonoBehaviour {

    int bananas = 0;
    public Text bananaCount;

	public void IncreaseBanana(int pAmount)
    {
        bananas += pAmount;
        bananaCount.text = bananas.ToString();
    }

    public int GetBananas()
    {
        return bananas;
    }
}
