using System;
using UnityEngine;

public class Enemigo : MonoBehaviour, IDañable
{
    [Header("Datos del enemigo")]
    public DatosEnemigo datos;

    [Header("Partícula")]
    [Tooltip("Tiempo en segundos antes de destruir la partícula de muerte")]
    public float tiempoVidaParticula = 2f;

    public event Action OnEnemigoMuerto;

    private int vidaActual;

    private void Start()
    {
        vidaActual = datos.vida;
    }

    private void Update()
    {
        transform.Translate(Vector3.down * datos.velocidadMovimiento * Time.deltaTime);
    }

    public void RecibirDaño(int cantidad)
    {
        vidaActual -= cantidad;

        if (vidaActual <= 0)
            Morir();
    }

    private void Morir()
    {
        if (datos.particulaMuerte != null)
        {
            GameObject particula = Instantiate(datos.particulaMuerte, transform.position, Quaternion.identity);
            Destroy(particula, tiempoVidaParticula);
        }

        OnEnemigoMuerto?.Invoke();
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vida vidaJugador = other.GetComponent<Vida>();
            if (vidaJugador != null)
            {
                vidaJugador.RecibirDaño(datos.daño);
            }
        }
    }
}