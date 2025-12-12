using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum EstadoJuego
    {
        Jugando,
        Victoria,
        Derrota
    }

    [Header("Estado Actual")]
    public EstadoJuego estadoActual = EstadoJuego.Jugando;

    [Header("Nombre de Escenas")]
    public string escenaVictoria = "Victoria";
    public string escenaDerrota = "GameOver";

    public static GameManager Instancia;

    private void Awake()
    {
        if (Instancia == null)
            Instancia = this;
        else
            Destroy(gameObject);
    }

    public void ActivarVictoria()
    {
        if (estadoActual != EstadoJuego.Jugando)
            return;

        estadoActual = EstadoJuego.Victoria;
        SceneManager.LoadScene(escenaVictoria);
    }

    public void ActivarDerrota()
    {
        if (estadoActual != EstadoJuego.Jugando)
            return;

        estadoActual = EstadoJuego.Derrota;
        SceneManager.LoadScene(escenaDerrota);
    }
}
