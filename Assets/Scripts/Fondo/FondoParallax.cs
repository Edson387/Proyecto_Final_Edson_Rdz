using UnityEngine;

public class FondoParallax : MonoBehaviour
{
    [Header("Velocidad del fondo")]
    [SerializeField, Range(0.01f, 1f)] private float velocidadScroll = 0.1f;

    private Renderer renderFondo;
    private Vector2 offset;

    void Start()
    {
        renderFondo = GetComponent<Renderer>();
    }

    void Update()
    {
        offset.y += velocidadScroll * Time.deltaTime;
        renderFondo.material.mainTextureOffset = offset;
    }
}
