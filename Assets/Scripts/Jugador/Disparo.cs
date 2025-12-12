using UnityEngine;

public class Disparo : MonoBehaviour
{
    [Header("Puntos de Disparo")]
    [SerializeField] private Transform puntoDeDisparo1;
    [SerializeField] private Transform puntoDeDisparo2;

    [Header("Tiempo entre disparos")]
    [SerializeField, Range(0.1f, 1f)] private float tiempoEntreDisparo = 1f;
    [SerializeField] private float tiempoUltimoDisparo = 0f;

    [Header("Prefab de la Bala")]
    [SerializeField] GameObject Bala;

    private void Start()
    {
        tiempoUltimoDisparo = -tiempoEntreDisparo;
    }

    void Update()
    {
        //Condicion que detecta si se presiona el espacio
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Disparar();
        }
    }

    void Disparar()
    {
        if (Time.time > tiempoUltimoDisparo + tiempoEntreDisparo)
        {
            Instantiate(Bala, puntoDeDisparo1.position, puntoDeDisparo1.rotation);
            Instantiate(Bala, puntoDeDisparo2.position, puntoDeDisparo2.rotation);

            tiempoUltimoDisparo = Time.time;
        }
        
    }
}
