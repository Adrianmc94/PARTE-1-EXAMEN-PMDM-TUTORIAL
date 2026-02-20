using UnityEngine;

public class Rotator : MonoBehaviour {
    // Definimos la rotación por segundo
    void Update() {
        // Rota el objeto en los tres ejes para que se vea dinámico
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}