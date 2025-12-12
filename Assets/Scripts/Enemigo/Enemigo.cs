using System;
using UnityEngine;

public class Enemigo : MonoBehaviour, IDañable
{
    [Header("Datos del enemigo")]
    public DatosEnemigo datos;

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
            Instantiate(datos.particulaMuerte, transform.position, Quaternion.identity);

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