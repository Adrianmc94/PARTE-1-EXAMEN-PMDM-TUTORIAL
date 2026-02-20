using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para reiniciar

public class ZonaMuerte : MonoBehaviour
{
    void Update()
    {
        // Si la bola cae por debajo de -10 en el eje Y
        if (transform.position.y < -10f)
        {
            // Reinicia la escena actual
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}