using UnityEngine;
using TMPro;

public class Contador : MonoBehaviour
{
    [Header("Texto del contador")]
    [SerializeField] private TextMeshProUGUI textoContador;

    [Header("Tiempo entre incrementos (segundos)")]
    [SerializeField, Range(0.1f, 2f)] private float tiempoEntreIncrementos = 1f;

    private float tiempoUltimoIncremento = 0f;
    private int contador = 0;

    void Update()
    {
        // Verifica si pasó el tiempo suficiente
        if (Time.time > tiempoUltimoIncremento + tiempoEntreIncrementos)
        {
            contador++;
            textoContador.text = contador.ToString();

            tiempoUltimoIncremento = Time.time;
        }
    }
}
