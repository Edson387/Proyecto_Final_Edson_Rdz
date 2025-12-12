using UnityEngine;

[CreateAssetMenu(fileName = "NuevoEnemigo", menuName = "Enemigo/Config Enemigo")]
public class DatosEnemigo : ScriptableObject
{
    [Header("Datos")]
    public string nombreEnemigo;

    [Header("Prefab")]
    public GameObject prefabEnemigo;

    [Header("Estadísticas")]
    public int vida;
    public float velocidadMovimiento;
    public int daño;

    [Header("Partícula al morir")]
    public GameObject particulaMuerte;
}
