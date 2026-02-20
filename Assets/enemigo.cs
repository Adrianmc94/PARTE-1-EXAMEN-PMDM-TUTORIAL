using UnityEngine;

public class EnemigoPersigue : MonoBehaviour 
{
    // Arrastra el objeto Player a este hueco en el Inspector
    public Transform bola; 
    
    // Velocidad a la que el cubo seguirá a la bola
    public float velocidad = 3f;

    void Update() 
    {
        // Si el objeto bola está asignado
        if (bola != null) 
        {
            // Mueve la posición del cubo hacia la posición de la bola de forma constante
            transform.position = Vector3.MoveTowards(transform.position, bola.position, velocidad * Time.deltaTime);
        }
    }

    // Opcional: Para que siga saliendo el mensaje de contacto del examen
    private void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.CompareTag("Player")) 
        { 
            Debug.Log("¡CONTACTO DETECTADO! El enemigo ha alcanzado al jugador.");
        }
    }
}