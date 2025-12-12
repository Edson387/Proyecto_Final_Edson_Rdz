using UnityEngine;
using TMPro;

public class Puntaje : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textoPuntaje;
    private int puntajeActual = 0;

    void Start()
    {
        ActualizarTexto();
    }

    public void SumarPuntos(int cantidad)
    {
        puntajeActual += cantidad;
        ActualizarTexto();
    }

    public void ReiniciarPuntaje()
    {
        puntajeActual = 0;
        ActualizarTexto();
    }

    private void ActualizarTexto()
    {
        textoPuntaje.text = puntajeActual.ToString();
    }
}