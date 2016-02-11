using UnityEngine;
using System.Collections;

public class ScriptMoveWithPlatform : MonoBehaviour {

    public bool onPlatform = false;
    public Transform platform = null;

	public void SetOnPlatform()
    {
        if (onPlatform && platform != null)
        {
            transform.parent.transform.SetParent(platform);
        }
        else
        {
            transform.parent = null;
        }
    }
}
 