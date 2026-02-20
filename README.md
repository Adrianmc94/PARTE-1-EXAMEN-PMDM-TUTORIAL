# Examen PMDM: Roll a Ball Pro - IA y Mecánicas Avanzadas

Este proyecto expande el tutorial básico de Unity "Roll a Ball", integrando sistemas de inteligencia artificial, gestión de estados, recolección y una interfaz de usuario completa.


## 1. Implementación de la IA 
El enemigo (cubo) posee un comportamiento dinámico basado en la posición del jugador:
* **Detección de Contacto (Debug):** Se utiliza el método `OnCollisionEnter` para lanzar un mensaje por consola al producirse un choque físico.
* **Variantes de Detección:** * `OnCollisionEnter`: Usada para impactos físicos (el cubo es sólido).
    * `OnTriggerEnter`: Usada para recolectables (la bola los atraviesa).
    * `OnCollisionStay`: Podría usarse para daño continuo mientras se toca al enemigo.


## 2. Movimiento y Física del Jugador
* **Fuerza Aplicada:** El movimiento se realiza mediante `rb.AddForce` en el método `FixedUpdate`, cumpliendo con el requisito de usar físicas en lugar de traslación directa.
* **Control:** Configurado mediante `Input.GetAxis` para soporte de teclado (WASD/Flechas).
* **Salto:** Se ha implementado un impulso vertical instantáneo usando `ForceMode.Impulse`.


## 3. Sistema de Cámara Dinámica
Para una experiencia de juego en tercera persona:
* **Lógica de Offset:** En el `Start`, el script calcula la distancia inicial entre la cámara y el jugador.
* **LateUpdate:** Se utiliza este método para que la cámara se mueva justo después que el jugador, evitando vibraciones (jittering) y manteniendo una perspectiva fluida.


## 4. Mecánica de Recolectables (Monedas)
* **Is Trigger:** Configurado en los Colliders para permitir que la bola recoja los objetos sin chocar con ellos.
* **Script Rotator:** Uso de `transform.Rotate` para dar feedback visual de que el objeto es un ítem especial.
* **Recolección:** Uso de `OnTriggerEnter` y `CompareTag("Moneda")` para gestionar la desaparición del objeto y sumar puntos al contador.


## 5. Interfaz de Usuario (UI) y Gestión de Escena
Se utiliza **TextMeshPro** para el feedback en tiempo real:
* **Victoria:** Al recoger todas las monedas, se activa el mensaje "¡HAS GANADO!" en verde.
* **Derrota:** Al colisionar con el enemigo, el mensaje "¡HAS PERDIDO!" aparece en rojo y se congela el movimiento del jugador.
* **Zona de Muerte:** Si el jugador cae al vacío (Y < -10), se utiliza `SceneManager.LoadScene` para reiniciar el nivel automáticamente.


## 6. Estructura de Tags (Configuración del Inspector)
* **Player:** Bola principal.
* **Moneda:** Objetos recolectables.
* **Enemigo:** Cubo con IA de persecución.

  <img width="1052" height="605" alt="Captura desde 2026-02-20 11-42-59" src="https://github.com/user-attachments/assets/bac1d3a0-cc1c-4ae7-bc97-4c15daff0d3a" />

