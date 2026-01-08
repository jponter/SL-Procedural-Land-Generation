using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Audio.ControlContext;

public class MapDisplay : MonoBehaviour
{

    public Renderer textureRender;
    public MeshFilter meshFilter;
    public MeshRenderer meshRenderer;

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

    public void DrawMesh(MeshData meshData, Texture2D texture)
    {
        meshFilter.sharedMesh = meshData.CreateMesh();
        //    Material mat = new Material(Shader.Find("Unlit/Texture"));
        //    mat.mainTexture = texture;
        //    meshRenderer.material = mat;
        //
        meshRenderer.sharedMaterial.mainTexture = texture;

    }

}
