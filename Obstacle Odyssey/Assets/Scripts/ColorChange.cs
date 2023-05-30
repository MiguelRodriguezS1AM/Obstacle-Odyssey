using UnityEngine;
using UnityEngine.UI;

public class ColorChange : MonoBehaviour
{
    public Text numberText;  // Referencia al objeto de texto que muestra el número
    public string startColorHex = "#FFFFFF";  // Color inicial en formato hexadecimal
    public string targetColorHex = "#0000FF";  // Color objetivo en formato hexadecimal
    public string targetTwoHex = "#FFFFFF";
    public string targetTreeHex = "#FFFFFF";
    public float duration = 2.0f;  // Duración de la transición

    private float currentTime = 0.0f;
    private Renderer objectRenderer;
    private Color startColor;
    private Color targetColor;
    private Color targetTwo;
    private Color targetTree;
    private bool startChangingColor = false;
    private bool changingColorTwo = false;
    private bool changeTree = false;

    private void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        startColor = ColorUtility.TryParseHtmlString(startColorHex, out Color color) ? color : Color.white;
        targetColor = ColorUtility.TryParseHtmlString(targetColorHex, out color) ? color : Color.blue;
        targetTwo = ColorUtility.TryParseHtmlString(targetTwoHex, out color) ? color : Color.white;
        targetTree = ColorUtility.TryParseHtmlString(targetTreeHex, out color) ? color : Color.white;

        // Establecer el color inicial al iniciar el juego
        objectRenderer.material.color = startColor;
    }

    private void Update()
    {
        // Verificar si el número en el objeto de texto es igual a 10
        int num = int.Parse(numberText.text);
        if (!startChangingColor && num == 10)
        {
            startChangingColor = true;
        }

        if (startChangingColor && !changingColorTwo && num < 20)
        {
            objectRenderer.material.color = targetColor;
        }

        if (changingColorTwo && !changeTree && num < 30)
        {
            objectRenderer.material.color = targetColor;
        }

        // Verificar si el número en el objeto de texto es igual a 20
        if (startChangingColor && !changingColorTwo && num == 20)
        {
            changingColorTwo = true;
            currentTime = 0.0f; // Reiniciar el tiempo para la transición del segundo color
        }

        // Si el cambio de color ha comenzado, realizar la transición
        if (startChangingColor && !changingColorTwo)
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
        else if (changingColorTwo)
        {
            // Incrementar el tiempo transcurrido
            currentTime += Time.deltaTime;

            // Calcular el factor de interpolación
            float t = Mathf.Clamp01(currentTime / duration);

            // Interpolar el color entre el color objetivo y el segundo objetivo
            Color currentColor = Color.Lerp(targetColor, targetTwo, t);

            // Asignar el color al objeto
            objectRenderer.material.color = currentColor;
        }
        else if (changeTree)
        {
            // Incrementar el tiempo transcurrido
            currentTime += Time.deltaTime;

            // Calcular el factor de interpolación
            float t = Mathf.Clamp01(currentTime / duration);

            // Interpolar el color entre el color objetivo y el segundo objetivo
            Color currentColor = Color.Lerp(targetTwo, targetTree, t);

            // Asignar el color al objeto
            objectRenderer.material.color = currentColor;
        }
    }
}