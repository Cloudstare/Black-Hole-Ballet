using UnityEngine;

[ExecuteInEditMode, ImageEffectAllowedInSceneView]
[RequireComponent(typeof(Camera))]
public class ApplyVignette : MonoBehaviour
{
    public Material vignetteMaterial;

    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        Debug.Log("OnRenderImage called");
        if (vignetteMaterial != null)
        {
            Graphics.Blit(src, dest, vignetteMaterial);
        }
        else
        {
            Graphics.Blit(src, dest);
        }
    }
}
