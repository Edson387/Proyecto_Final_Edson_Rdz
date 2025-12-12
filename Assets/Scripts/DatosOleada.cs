using UnityEngine;

[CreateAssetMenu(fileName = "NuevaOleada", menuName = "Oleada/Config Oleada")]
public class DatosOleada : ScriptableObject
{
    [Header("Enemigo que aparecera en esta Oleada")]
    public DatosEnemigo enemigo;

    [Header("Cantidad total a Spawnear")]
    public int cantidadEnemigos = 5;

    [Header("Tiempo entre cada aparicion")]
    public float tiempoEntreEnemigos = 1f;

    [Header("Tiempo de espera antes de iniciar la Oleada")]
    public float retrasoInicial = 2f;
}
