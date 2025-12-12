using UnityEngine;

public class Vida : MonoBehaviour
{
    [Header("Vida de la base")]
    public int vidaMaxima = 5;
    public int vidaActual;

    private void Start()
    {
        vidaActual = vidaMaxima;
    }

    public void RecibirDaño(int daño)
    {
        vidaActual -= daño;

        if (vidaActual <= 0)
            Morir();
    }

    private void Morir()
    {
        GameManager.Instancia.ActivarDerrota();
        Destroy(gameObject);
    }
}
