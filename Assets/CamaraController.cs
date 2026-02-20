using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Arrastra aquí a tu Player desde el Inspector
    public GameObject player;

    // Distancia entre la cámara y el jugador
    private Vector3 offset;

    void Start()
    {
        // Calculamos la distancia inicial al empezar el juego
        offset = transform.position - player.transform.position;
    }

    // LateUpdate se ejecuta después de que el Player se haya movido
    void LateUpdate()
    {
        // Mantenemos la misma distancia pero actualizamos la posición
        transform.position = player.transform.position + offset;
    }
}