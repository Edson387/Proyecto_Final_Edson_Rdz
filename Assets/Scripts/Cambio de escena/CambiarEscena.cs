using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    [Header("Nombre de la escena a cargar")]
    public string nombreEscena;

    // Método público que se puede llamar desde UI o desde otro script
    public void CargarEscena()
    {
        if (!string.IsNullOrEmpty(nombreEscena))
        {
            SceneManager.LoadScene(nombreEscena);
        }
        else
        {
            Debug.LogWarning("No se ha asignado un nombre de escena.");
        }
    }
}
