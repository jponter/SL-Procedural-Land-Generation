using UnityEngine;

public static class TextureGenerator
{

    public static Texture2D TextureFromColorMap(Color[] colorMap, int width, int height)
    {
        Texture2D texture = new Texture2D(width, height);
        texture.filterMode = FilterMode.Point;
        texture.wrapMode = TextureWrapMode.Clamp;
        texture.SetPixels(colorMap);
        texture.Apply();

        


        return texture;
    }

    public static Texture2D TextureFromHeightMap(float[,] heightMap)
    {
        int width = heightMap.GetLength(0);
        int height = heightMap.GetLength(1);

        //if(localTextureScale <= 0)  
        //{
        //    localTextureScale = 1;
        //}


        //if (pointFilter) texture.filterMode = FilterMode.Point;

        Color[] colorMap = new Color[width * height];

        float minVal = 1f, maxVal = 0f;

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                float value = heightMap[x, y];
                if (value < minVal) minVal = value;
                if (value > maxVal) maxVal = value;
                colorMap[y * width + x] = Color.Lerp(Color.black, Color.white, heightMap[x, y]);
            }
        }

        return TextureFromColorMap(colorMap, width, height);


    }
}
