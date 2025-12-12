using UnityEngine;

public class DestruirEnemigo : MonoBehaviour
{
    [Header("Daño que causa el disparo")]
    [SerializeField] private int daño = 1;

    private void OnTriggerEnter(Collider colision)
    {
        // Intentamos obtener cualquier objeto que implemente IDañable
        IDañable objetivo = colision.GetComponent<IDañable>();
        if (objetivo != null)
        {
            objetivo.RecibirDaño(daño);
            // No destruimos el objeto para que pueda seguir aplicando daño
        }
    }
}
