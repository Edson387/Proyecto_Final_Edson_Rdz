using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class MovimientoJugador : MonoBehaviour
{
    [Header("Velocidad Jugador")]
    [SerializeField] private float velocidad = 2f;

    [Header("Limites laterales")]
    [SerializeField] private float limiteIzquierdo = 0f;
    [SerializeField] private float limiteDerecho = 0f;

    private float movimiento;

    private float limites;

    void Update()
    {
        //Guarda los valos de X y los multiplica por la velocidad y la cantidad de frames
        movimiento =  Input.GetAxis("Horizontal") * velocidad * Time.deltaTime;

        //Aplica los valores de X guardados en movimiento para trasladar el objeto
        transform.Translate(movimiento, 0, 0);

        //Guarda los limites laterales
        limites = Mathf.Clamp(transform.position.x, limiteIzquierdo, limiteDerecho);

        //Pasa la nueva posicion tomando en cuenta los limites establecidos
        transform.position = new Vector3(limites, transform.position.y, transform.position.z);
    }
}
