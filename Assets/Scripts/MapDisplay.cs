using UnityEngine;
using System.Collections;

public class MapDisplay : MonoBehaviour {

    public Renderer textureRenderer;

    public void DrawNoiseMapTexture(float[,] noiseMap, Color colorA, Color colorB) {
        int width = noiseMap.GetLength(0);
        int height = noiseMap.GetLength(1);

        Texture2D tex = new Texture2D(width, height);

        Color[] colorMap = new Color[width * height];
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                colorMap[x * width + y] = Color.Lerp(colorA, colorB, noiseMap[x, y]);
            }
        }

        tex.SetPixels(colorMap);
        tex.Apply();

        textureRenderer.sharedMaterial.mainTexture = tex;
        textureRenderer.transform.localScale = new Vector3(width, 1, height); // set the plane size to the same as the texture
    }
}
