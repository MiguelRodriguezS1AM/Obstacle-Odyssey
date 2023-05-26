using UnityEngine;
using UnityEngine.UI;

public class ColorChange : MonoBehaviour
{
    public Text numberText;  // Referencia al objeto de texto que muestra el número
    public string startColorHex = "#FFFFFF";  // Color inicial en formato hexadecimal
    public string targetColorHex = "#0000FF";  // Color objetivo en formato hexadecimal
    public float duration = 2.0f;  // Duración de la transición

    private float currentTime = 0.0f;
    private Renderer objectRenderer;
    private Color startColor;
    private Color targetColor;
    private bool startChangingColor = false;

    private void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        startColor = ColorUtility.TryParseHtmlString(startColorHex, out Color color) ? color : Color.white;
        targetColor = ColorUtility.TryParseHtmlString(targetColorHex, out color) ? color : Color.blue;

        // Establecer el color inicial al iniciar el juego
        objectRenderer.material.color = startColor;
    }

    private void Update()
    {
        // Verificar si el número en el objeto de texto es igual a 5
        if (!startChangingColor && numberText.text == "5")
        {
            startChangingColor = true;
        }

        // Si el cambio de color ha comenzado, realizar la transición
        if (startChangingColor)
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
}
