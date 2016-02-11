using UnityEngine;
using System.Collections;

/// <summary>
/// @Author: Andrew Seba
/// @Description: Scrolls the texture on its y axis.
/// Object can't be static*
/// </summary>
public class ScriptTextureScroll : MonoBehaviour {

    public float scrollSpeed = 0.1f;
    private Mesh mesh;

	// Use this for initialization
	void Start () {
        mesh = transform.GetComponent<MeshFilter>().mesh;
	}
	
	// Update is called once per frame
	void Update () {
        SwapUVs();
	}

    void SwapUVs()
    {
        Vector2[] uvSwap = mesh.uv;

        for(int b = 0; b < uvSwap.Length; b ++){
            uvSwap[b] += new Vector2(0, (scrollSpeed * Time.deltaTime)*-1);
        }

        mesh.uv = uvSwap;
    }
}
