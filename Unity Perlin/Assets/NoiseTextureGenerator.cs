using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseTextureGenerator : MonoBehaviour {

    public int height = 256;
    public int width = 256;

    public PerlinGenerator pg;

    private void Start()
    {
        Renderer r = GetComponent<Renderer>();

        r.material.mainTexture = GenerateTexture();
    }

    Texture2D GenerateTexture()
    {
        Texture2D texture = new Texture2D(width, height);


        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                Color color = CalculateColor(x, y);
                texture.SetPixel(x, y, color);
            }
        }

        texture.filterMode = FilterMode.Point;

        texture.Apply();
        return texture;
    }

    Color CalculateColor(int x, int y)
    {
        float xCoord = (float)x / width;
        float yCoord = (float)y / height;

        float val = pg.GetPerlin(xCoord, yCoord, 0.0f);
        return new Color(val, val, val);
    }
}
