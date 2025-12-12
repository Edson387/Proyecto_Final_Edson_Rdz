using UnityEngine;
using UnityEngine.SceneManagement;

public class Asteroide : MonoBehaviour
{
    [Header("Velocidad del Asteroide")]
    [SerializeField] private float velocidad = 10f;

    [Header("Tiempo en Destruirse")]
    [SerializeField] private float tiempoVida = 3f;

    [Header("Puntos que otorga al ser destruido")]
    [SerializeField] private int puntos = 1;

    [Header("Nombre de la escena")]
    [SerializeField] private string nombreEscena;

    private Puntaje puntaje;

    private void Awake()
    {
        //Busca en la escena el objeto con el componente Puntaje
        puntaje = FindObjectOfType<Puntaje>();
    }

    private void Start()
    {
        Destroy(gameObject, tiempoVida);
    }

    void Update()
    {
        transform.Translate(Vector3.down * velocidad * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider colision)
    {
        if (colision.CompareTag("Player"))
        {
            Destroy(colision.gameObject);

            if (puntaje != null)
                puntaje.ReiniciarPuntaje();

            ReiniciarEscena();
        }
        else if (colision.CompareTag("Bala"))
        {
            if (puntaje != null)
                puntaje.SumarPuntos(puntos);

            Destroy(colision.gameObject);
            Destroy(gameObject);
        }
    }

    private void ReiniciarEscena()
    {
        SceneManager.LoadScene(nombreEscena);
    }
}