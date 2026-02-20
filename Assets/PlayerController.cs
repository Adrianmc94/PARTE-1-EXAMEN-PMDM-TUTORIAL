using UnityEngine;
using TMPro; // Necesario para controlar el texto en pantalla

public class PlayerController : MonoBehaviour
{
    public float speed = 15f; 
    private Rigidbody rb;
    
    private int contador = 0; // Para contar monedas
    public int monedasTotales = 5; // Pon aquí el número de monedas que hayas puesto
    public TextMeshProUGUI textoFinal; // Arrastra aquí el objeto TextoFinal

    void Start() {
        rb = GetComponent<Rigidbody>();
        textoFinal.gameObject.SetActive(false); // Asegura que empiece oculto
    }

    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }

    // CUANDO GANAS (Pillas monedas)
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Moneda")) {
            other.gameObject.SetActive(false);
            contador++; // Suma 1 al contador
            
            if (contador >= monedasTotales) {
                textoFinal.text = "¡HAS GANADO!";
                textoFinal.color = Color.green;
                textoFinal.gameObject.SetActive(true);
            }
        }
    }

    // CUANDO PIERDES (Te toca el enemigo)
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Enemigo")) {
            textoFinal.text = "¡HAS PERDIDO!";
            textoFinal.color = Color.red;
            textoFinal.gameObject.SetActive(true);
            
            // Opcional: Detener el movimiento de la bola
            this.enabled = false; 
            rb.velocity = Vector3.zero;
        }
    }
}