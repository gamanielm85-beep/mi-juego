using UnityEngine;

public class CamaraSigue : MonoBehaviour
{
    public Transform objetivo;                 // El jugador (si lo dejas vacío, lo busca solo)
    public float suavizado = 0.15f;            // Menos número = la cámara va más pegada
    public Vector2 desfase = new Vector2(0, 1);
    public float alturaMinima = -3f;           // La cámara no baja de aquí (así ves al jugador caer)

    Vector3 velocidadActual;

    void Start()
    {
        // Si no asignaste el objetivo, busca el objeto con Tag "Player"
        if (objetivo == null)
        {
            GameObject j = GameObject.FindGameObjectWithTag("Player");
            if (j != null) objetivo = j.transform;
        }
    }

    // LateUpdate: se mueve después del jugador, evita temblores
    void LateUpdate()
    {
        if (objetivo == null) return;

        float x = objetivo.position.x + desfase.x;
        float y = Mathf.Max(objetivo.position.y + desfase.y, alturaMinima);
        Vector3 destino = new Vector3(x, y, -10f);   // Z fija en -10

        transform.position = Vector3.SmoothDamp(transform.position, destino, ref velocidadActual, suavizado);
    }
}