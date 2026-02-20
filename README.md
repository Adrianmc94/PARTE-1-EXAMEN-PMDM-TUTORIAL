# PARTE-1-EXAMEN-PMDM-TUTORIAL

# Mejoras de Gameplay: Roll a Ball Pro

Este documento detalla la implementación de las mecánicas de juego avanzadas: el sistema de recolección, la interfaz de usuario (UI) de estado y el sistema de cámara dinámica.


## 1. Sistema de Cámara
Para que el proyecto se comporte como un videojuego en tercera persona, se ha implementado un script de seguimiento:
* **Lógica de Offset:** En el `Start`, el script calcula la distancia inicial entre la cámara y el jugador.
* **LateUpdate:** Se utiliza este método para actualizar la posición de la cámara. Al ejecutarse justo después del movimiento del jugador, se eliminan los temblores (jittering), manteniendo la perspectiva constante mientras la bola rueda.
* 

## 2. Mecánica de Recolectables (Monedas)
Las monedas utilizan un sistema de detección pasiva para no frenar el avance del jugador:
* **Is Trigger:** Se ha activado esta opción en el Collider de las monedas para que la bola pueda "atravesarlas".
* **Script Rotator:** Mediante `transform.Rotate`, las monedas giran constantemente sobre sus tres ejes, dándoles un aspecto visual dinámico.
* **Recolección:** El script del jugador detecta el tag **"Moneda"** mediante `OnTriggerEnter` y utiliza `gameObject.SetActive(false)` para hacerlas desaparecer de la escena al contacto.


## 3. Interfaz de Usuario (UI) y Lógica de Estados
Se ha integrado un sistema de feedback visual mediante **TextMeshPro** para informar al jugador de su progreso:

### Condición de Victoria
* **Contador:** El `PlayerController` lleva una variable entera que aumenta con cada moneda recogida.
* **Activación:** Al alcanzar el número total de monedas, se activa un objeto de texto en pantalla con el mensaje "¡HAS GANADO!" en color verde.

### Condición de Derrota
* **Detección de Peligro:** Si el jugador colisiona físicamente con un objeto etiquetado como **"Enemigo"**, el script activa el mensaje "¡HAS PERDIDO!" en color rojo.
* **Paralización:** Al perder, se desactiva el script de movimiento y se detiene la velocidad del Rigidbody para que el jugador no pueda seguir moviéndose.


## 4. Estructura de Tags Utilizada
Para que el código identifique correctamente cada interacción, se han configurado los siguientes identificadores en el Inspector:
* **Player:** Asignado a la bola principal.
* **Moneda:** Asignado a todos los objetos recolectables.
* **Enemigo:** Asignado al cubo que persigue al jugador.
