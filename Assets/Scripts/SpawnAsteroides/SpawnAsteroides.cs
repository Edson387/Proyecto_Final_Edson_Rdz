using UnityEngine;

public class SpawnAsteroides : MonoBehaviour
{
    [Header("Rango de aparición en X")]
    [SerializeField] private float xMin = -10f;
    [SerializeField] private float xMax = 10f;

    [Header("Prefab del asteroide")]
    [SerializeField] private GameObject prefabAsteroide;

    [Header("Tiempo entre spawns")]
    [SerializeField, Range(0.2f, 3f)] private float tiempoEntreSpawn = 1f;
    private float tiempoUltimoSpawn = 0f;

    private void Update()
    {
        if (Time.time > tiempoUltimoSpawn + tiempoEntreSpawn)
        {
            GenerarAsteroide();
            tiempoUltimoSpawn = Time.time;
        }
    }

    private void GenerarAsteroide()
    {
        if (prefabAsteroide == null)
        {
            Debug.LogWarning("No hay prefab de asteroide asignado.");
            return;
        }

        // Genera una posición aleatoria en X, manteniendo la Y y Z del objeto spawner
        float posicionX = Random.Range(xMin, xMax);
        Vector3 posicionSpawn = new Vector3(posicionX, transform.position.y, transform.position.z);

        Instantiate(prefabAsteroide, posicionSpawn, Quaternion.identity);
    }
}
