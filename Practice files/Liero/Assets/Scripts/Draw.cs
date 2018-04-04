using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw : MonoBehaviour {

	// Use this for initialization
	void Start () {
        // This small script will color main texture with other colors
        Texture2D texture = new Texture2D(450, 450); //600 450
        texture.filterMode = FilterMode.Point;
        GetComponent<Renderer>().material.mainTexture = texture;


        for(int y=0; y<texture.height; y++)
        {
            for(int x=0;x<texture.width;x++)
            {
                Color color = ((x & y) != 0 ? Color.green : Color.blue);
                texture.SetPixel(x, y, color);
            }
        }



        texture.SetPixel(10, 10, Color.red);
        
        // importatnt. without this coloring doesn't work
        texture.Apply();
	}


	
}
