using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [Header("Configuración de Oleadas")]
    public List<DatosOleada> listaOleadas;
    public Transform[] puntosSpawn;
    public float tiempoEntreOleadas = 5f;

    [Header("Estado Actual")]
    public int oleadaActual = 0;
    public bool oleadaActiva = false;

    [HideInInspector]
    public ModoControl modoControl = ModoControl.Automatico;

    private int enemigosVivos = 0;
    private GameManager gameManager;

    
    public enum ModoControl { Automatico, Manual }

    private void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();

        if (modoControl == ModoControl.Automatico)
        {
            StartCoroutine(ControlOleadas());
        }
    }

    public void IniciarOleadaManual()
    {
        if (!oleadaActiva)
        {
            StartCoroutine(ControlOleadas());
        }
    }

    private IEnumerator ControlOleadas()
    {
        while (oleadaActual < listaOleadas.Count)
        {
            yield return StartCoroutine(EjecutarOleada(listaOleadas[oleadaActual]));
            oleadaActual++;

            if (oleadaActual < listaOleadas.Count)
                yield return new WaitForSeconds(tiempoEntreOleadas);
        }

        gameManager.ActivarVictoria();
    }

    private IEnumerator EjecutarOleada(DatosOleada datos)
    {
        oleadaActiva = true;
        enemigosVivos = datos.cantidadEnemigos;

        for (int i = 0; i < datos.cantidadEnemigos; i++)
        {
            GenerarEnemigo(datos);
            yield return new WaitForSeconds(datos.tiempoEntreEnemigos);
        }

        yield return new WaitUntil(() => enemigosVivos <= 0);

        oleadaActiva = false;
    }

    private void GenerarEnemigo(DatosOleada datos)
    {
        Transform punto = puntosSpawn[Random.Range(0, puntosSpawn.Length)];

        GameObject nuevo = Instantiate(datos.enemigo.prefabEnemigo, punto.position, Quaternion.identity);

        Enemigo enemigo = nuevo.GetComponent<Enemigo>();
        enemigo.OnEnemigoMuerto += EnemigoMuerto;
    }

    private void EnemigoMuerto()
    {
        enemigosVivos--;
        Debug.Log("Enemigos restantes: " + enemigosVivos);
    }
}