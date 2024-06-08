using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class DynamicVignetteVolume : MonoBehaviour
{
    public Volume volume; // Przypisz Global Volume
    public Transform playerTransform; // Przypisz Transform gracza
    public Transform blackHoleTransform; // Przypisz Transform czarnej dziury
    public float maxIntensity = 1.0f; // Maksymalna intensywność winiety
    public float minDistance = 5.0f; // Minimalna odległość do czarnej dziury, przy której intensywność jest maksymalna
    public float maxDistance = 20.0f; // Maksymalna odległość do czarnej dziury, przy której intensywność jest minimalna

    private UnityEngine.Rendering.Universal.Vignette vignette; // Referencja do komponentu Vignette

    void Start()
    {
        if (volume != null && volume.profile != null)
        {
            // Pobierz komponent Vignette z profilu
            bool found = volume.profile.TryGet(out UnityEngine.Rendering.Universal.Vignette vignette);
            if (found)
            {
                this.vignette = vignette;
            }
            else
            {
                Debug.LogError("Vignette component not found in the profile.");
            }
        }
    }



    void Update()
    {
        GameObject blackHole = GameObject.FindGameObjectWithTag("BlackHole");
        if(blackHole == null)
        {
            Vector3 blackHolePosition = blackHole.transform.position;
            Debug.Log("Black Hole Position: " + blackHolePosition);
        }
        

        if (vignette != null && playerTransform != null)
        {
            // Przelicz pozycję gracza na współrzędne widoku kamery
            Vector3 screenPos = Camera.main.WorldToViewportPoint(playerTransform.position);
            Debug.Log("Screen Pos: " + screenPos);
            // Dopasuj wartość intensywności winiety na podstawie pozycji gracza
            float distanceFromCenter = Vector2.Distance(new Vector2(screenPos.x, screenPos.y), new Vector2(0.5f, 0.5f));
            
            
            
        }
    }
}
