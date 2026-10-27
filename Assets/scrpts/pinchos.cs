using UnityEngine;

public class pinchos : MonoBehaviour
{
    // Esto se activa si el Collider tiene "Is Trigger" MARCADO
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("¡Lava tocada (Trigger)!");
            Jugador scriptJugador = other.GetComponent<Jugador>();
            if (scriptJugador != null) scriptJugador.Morir();
        }
    }

    // Esto se activa si el Collider tiene "Is Trigger" DESMARCADO (choque físico)
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("¡Lava tocada (Colisión)!");
            Jugador scriptJugador = other.gameObject.GetComponent<Jugador>();
            if (scriptJugador != null) scriptJugador.Morir();
        }
    }
}