using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Audio.ControlContext;

public class MapDisplay : MonoBehaviour
{

    public Renderer textureRender;

    [HideInInspector]
    public bool pointFilter = false;
    //public int localTextureScale = 1;



    public void DrawNoiseMap(float[,] noiseMap)
    {
        int width = noiseMap.GetLength(0);
        int height = noiseMap.GetLength(1);

        //if(localTextureScale <= 0)  
        //{
        //    localTextureScale = 1;
        //}

        Texture2D texture = new Texture2D(width, height);
        if(pointFilter)texture.filterMode = FilterMode.Point;

        Color[] colorMap = new Color[width * height];

        float minVal = 1f, maxVal = 0f;

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                float value = noiseMap[x, y];
                if (value < minVal) minVal = value;
                if (value > maxVal) maxVal = value;
                colorMap[y * width + x] = Color.Lerp(Color.black, Color.white, noiseMap[x,y]);
            }
        }


        Debug.Log($"DrawNoiseMap received values: Min = {minVal}, Max = {maxVal}");

        texture.SetPixels(colorMap);
        texture.Apply();


        //create a new texture
        Material mat = new Material(Shader.Find("Unlit/Texture"));
        mat.mainTexture = texture;
        textureRender.material = mat;

        textureRender.transform.localScale = new Vector3(width, 1, height);
    }
}
