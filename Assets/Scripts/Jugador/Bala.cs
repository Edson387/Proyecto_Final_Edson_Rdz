using UnityEngine;

public class Bala : MonoBehaviour
{
    [Header("Velocidad del Disparo")]
    [SerializeField] private float velocidad = 10f;

    [Header("Daño que causa la bala")]
    [SerializeField] private int dano = 1;

    [Header("Tiempo en Destruirse")]
    [SerializeField] private float tiempoVida = 3f;

    private void Start()
    {
        Destroy(gameObject, tiempoVida);
    }

    private void Update()
    {
        transform.Translate(Vector3.up * velocidad * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider colision)
    {
        // Buscamos cualquier objeto que implemente IDañable
        IDañable objetivo = colision.GetComponent<IDañable>();
        if (objetivo != null)
        {
            objetivo.RecibirDaño(dano);
            Destroy(gameObject); // La bala siempre se destruye al impactar
        }
    }
}
