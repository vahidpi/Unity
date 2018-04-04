using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDraw : MonoBehaviour {
    public Camera cam;

	// Use this for initialization
	void Start () {
        cam = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!Input.GetMouseButton(0))
        {
            // if we don't have mouse button, then do not continue update
            return;
        }

        // this should ray to the mouse location on screen
        // hit results will be stored to the hit variable
        RaycastHit hit;
        if (!Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit))
        {
            // in this casethe ray hit nothing, so we don't continue update loop
            return;
        }

        // we have hit the object with ray
        Renderer rend = hit.transform.GetComponent<Renderer>();
        MeshCollider meshCollider = hit.collider as MeshCollider;

        // lets check that the background has all the feature we need to be
        // able to make drawing

        if(rend==null || rend.sharedMaterial==null || rend.sharedMaterial== null ||
            rend.sharedMaterial.mainTexture==null || meshCollider == null)
        {
            return;
        }

        // we are to do some painting
        Texture2D tex = rend.material.mainTexture as Texture2D;
        Vector2 pixelUV = hit.textureCoord;

        pixelUV.x *= tex.width;
        pixelUV.y *= tex.height;

        tex.SetPixel((int)pixelUV.x, (int)pixelUV.y, Color.clear);
        tex.Apply();
    } // Update

    public bool DrawRay(Vector3 testray)
    {
        RaycastHit hit;
        if (!Physics.Raycast(cam.ScreenPointToRay(cam.WorldToScreenPoint(testray)), out hit))
        {

            return false;
        }

     
        Renderer rend = hit.transform.GetComponent<Renderer>();
        MeshCollider meshCollider = hit.collider as MeshCollider;


        if (rend == null || rend.sharedMaterial == null || rend.sharedMaterial == null ||
            rend.sharedMaterial.mainTexture == null || meshCollider == null)
        {
            return false;
        }

       
        Texture2D tex = rend.material.mainTexture as Texture2D;
        Vector2 pixelUV = hit.textureCoord;

        pixelUV.x *= tex.width;
        pixelUV.y *= tex.height;

        // we check if the pixel aplpha value is 1.0
        if (tex.GetPixel((int)pixelUV.x, (int)pixelUV.y).a == 1.0)
        {
            return true;
        } else
        {
            return false;
        }
        //return false;
    }


    public bool PaintRay(Vector3 testray)
    {
        RaycastHit hit;
        if (!Physics.Raycast(cam.ScreenPointToRay(cam.WorldToScreenPoint(testray)), out hit))
        {

            return false;
        }


        Renderer rend = hit.transform.GetComponent<Renderer>();
        MeshCollider meshCollider = hit.collider as MeshCollider;


        if (rend == null || rend.sharedMaterial == null || rend.sharedMaterial == null ||
            rend.sharedMaterial.mainTexture == null || meshCollider == null)
        {
            return false;
        }


        Texture2D tex = rend.material.mainTexture as Texture2D;
        Vector2 pixelUV = hit.textureCoord;

        pixelUV.x *= tex.width;
        pixelUV.y *= tex.height;

        // we check if the pixel aplpha value is 1.0
        if (tex.GetPixel((int)pixelUV.x, (int)pixelUV.y).a == 1.0)
        {
            // ammo has hit the wall, let's draw a transparent circle to the texture

            Circle(tex, (int)pixelUV.x, (int)pixelUV.y, 10, Color.clear);
            tex.Apply();
            return true;
        }
        else
        {
            return false;
        }
        //return false;


    }

    public void Circle(Texture2D tex, int cx, int cy, int r, Color col)
    {
        int x, y, px, py, nx, ny, d;
        for (x = 0; x <= r; x++)
        {
            d = (int)Mathf.Ceil(Mathf.Sqrt(r * r - x * x));

            for (y = 0; y <= d; y++)
            {
                px = cx + x;
                nx = cx - x;
                py = cy + y;
                ny = cy - y;

                tex.SetPixel(px, py, col);
                tex.SetPixel(nx, py, col);

                tex.SetPixel(px, ny, col);
                tex.SetPixel(nx, ny, col);
            }
        }
    }
}
