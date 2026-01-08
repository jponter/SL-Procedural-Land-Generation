using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Audio.ControlContext;

public class MapDisplay : MonoBehaviour
{

    public Renderer textureRender;

    [HideInInspector]
    public bool pointFilter = false;
    //public int localTextureScale = 1;



    public void DrawTexture(Texture2D texture)
    {
        
        
        Debug.Log("Drawing Texture");

        //create a new texture
        Material mat = new Material(Shader.Find("Unlit/Texture"));
        mat.mainTexture = texture;
        textureRender.material = mat;

        textureRender.transform.localScale = new Vector3(texture.width, 1, texture.height);
    }
}
