using UnityEngine;

public class SH : MonoBehaviour
{
    [SerializeField]
    Material mat;

    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        Graphics.Blit(null, dest, mat);
    }
}
