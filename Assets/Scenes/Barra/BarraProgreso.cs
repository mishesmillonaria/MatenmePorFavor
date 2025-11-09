using UnityEngine;
using UnityEngine.UI;

public class BarraProgreso : MonoBehaviour
{
    public Image progressBar;
    public float fillSpeed = 0.3f;
    public float decaySpeed = 0.2f;

    private Vector3 lastMousePosition;
    private bool isMouseMoving = false;
    private float fillValue = 0f;
    public bool barIsFull { get; private set; } = false;

    void Start()
    {
        if (progressBar == null)
        {
            Debug.LogError("❌ Falta asignar la imagen de la barra de progreso.");
            enabled = false;
            return;
        }

        lastMousePosition = Input.mousePosition;
    }

    void Update()
    {
        isMouseMoving = (Input.mousePosition != lastMousePosition);

        if (isMouseMoving)
            fillValue += fillSpeed * Time.deltaTime;
        else
            fillValue -= decaySpeed * Time.deltaTime;

        fillValue = Mathf.Clamp01(fillValue);
        progressBar.fillAmount = fillValue;
        barIsFull = (fillValue >= 1f);

        lastMousePosition = Input.mousePosition;
    }

    public void ResetBarra()
    {
        fillValue = 0f;
        progressBar.fillAmount = 0f;
        barIsFull = false;
    }
}



