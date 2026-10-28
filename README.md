# Mi Juego

Un pequeño juego 2D desarrollado en Unity con C#. El proyecto incluye movimiento del personaje, salto, obstáculos, recolección de un objetivo final, sonido y sistema de victoria/derrota.

## Descripción

Este juego consiste en controlar a un personaje dentro de un nivel 2D, evitando trampas y obstáculos para alcanzar la meta. El jugador puede moverse con el teclado, saltar para sortear peligros y ganar al recoger el objeto final.

## Características

- Movimiento lateral del personaje
- Salto con física 2D
- Colisiones con obstáculos y pinchos
- Sistema de muerte y reinicio
- Pantallas de victoria y derrota
- Música de fondo y efectos de sonido
- Proyecto listo para abrirse en Unity

## Controles

- A / D o Flechas izquierda / derecha: mover al personaje
- Espacio: saltar

## Requisitos

- Unity 2022.3 LTS o superior
- Conocimientos básicos de Unity y C#
- Sistema operativo compatible con Unity

## Cómo ejecutar el proyecto

1. Descarga o clona este repositorio.
2. Abre la carpeta con Unity Hub.
3. Selecciona la versión de Unity recomendada (2022.3 LTS o posterior).
4. Abre la escena principal ubicada en:
   - `Assets/JUEGO.unity`
5. Presiona Play para probar el juego.

## Estructura del proyecto

- `Assets/`
  Contiene los recursos del juego, escenas, sprites, sonidos y prefabricados.
- `Assets/scrpts/`
  Scripts del juego en C#.
- `Packages/`
  Dependencias y configuración del proyecto Unity.
- `ProjectSettings/`
  Configuración del proyecto Unity.

## Scripts principales

- `Assets/scrpts/jugador.cs`
  Controla el movimiento, salto, muerte y animaciones del personaje.

- `Assets/scrpts/coin.cs`
  Detecta cuando el jugador recoge el objeto final y activa la victoria.

- `Assets/scrpts/pinchos.cs`
  Detecta el contacto con obstáculos mortales y provoca la muerte del jugador.

- `Assets/scrpts/GameManager.cs`
  Administra la música, los paneles de victoria/derrota y el reinicio de la escena.

## Objetivo del juego

Completar el nivel evitando obstáculos y llegando al punto de victoria. Si el personaje toca pinchos o cae fuera del nivel, el juego termina y se reinicia la escena.

## Estado del proyecto

Este proyecto se encuentra en desarrollo como un prototipo de juego 2D simple en Unity. Puede adaptarse y ampliarse con más niveles, enemigos, menús y mejoras visuales.

## Licencia

Este proyecto no incluye una licencia explícita en el repositorio. Si deseas usarlo en un proyecto personal o profesional, es recomendable contactar al autor antes de distribuirlo.

## Autor

- gamanielm85-beep
