using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public Color startColor = Color.white;  // Color inicial
    public Color targetColor = Color.blue;  // Color objetivo
    public float duration = 2.0f;  // Duración de la transición

    private float currentTime = 0.0f;
    private Renderer objectRenderer;

    private void Start()
    {
        objectRenderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        // Incrementar el tiempo transcurrido
        currentTime += Time.deltaTime;

        // Calcular el factor de interpolación
        float t = Mathf.Clamp01(currentTime / duration);

        // Interpolar el color entre el color inicial y el objetivo
        Color currentColor = Color.Lerp(startColor, targetColor, t);

        // Asignar el color al objeto
        objectRenderer.material.color = currentColor;
    }
}
