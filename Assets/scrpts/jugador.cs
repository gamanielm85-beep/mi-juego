using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class Jugador : MonoBehaviour
{
    public float velocidad = 6f;
    public float fuerzaDeSalto = 9f;
    public float tiempoMuerte = 1f;

    Rigidbody2D rb;
    Animator anim;
    Vector3 posInicial;
    Vector3 escalaInicial;
    int contactosSuelo;
    bool muerto;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        posInicial = transform.position;
        escalaInicial = transform.localScale;
    }

    void Update()
    {
        if (muerto) return;

        var teclado = Keyboard.current;
        if (teclado == null) return;

        float mover = 0f;
        if (teclado.aKey.isPressed || teclado.leftArrowKey.isPressed) mover = -1f;
        if (teclado.dKey.isPressed || teclado.rightArrowKey.isPressed) mover = 1f;
        rb.linearVelocity = new Vector2(mover * velocidad, rb.linearVelocity.y);

        if (teclado.spaceKey.wasPressedThisFrame && contactosSuelo > 0)
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaDeSalto);

        if (mover != 0)
            transform.localScale = new Vector3(
                Mathf.Sign(mover) * Mathf.Abs(escalaInicial.x),
                escalaInicial.y,
                escalaInicial.z);

        if (anim != null)
        {
            anim.SetFloat("Velocidad", Mathf.Abs(mover));
            anim.SetBool("EnSuelo", contactosSuelo > 0);
        }

        if (transform.position.y < -10f) Morir();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        foreach (var c in col.contacts)
            if (c.normal.y > 0.5f) { contactosSuelo++; break; }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        contactosSuelo = Mathf.Max(0, contactosSuelo - 1);
    }

    public void Morir()
    {
        if (muerto) return;
        StartCoroutine(RutinaMuerte());
    }

    IEnumerator RutinaMuerte()
    {
        muerto = true;
        
        //  APAGAMOS LA FÍSICA Y EL COLLIDER PARA QUE NO VUELVA A TOCAR LA LAVA
        rb.linearVelocity = Vector2.zero;
        rb.simulated = false; 
        
        Collider2D col = GetComponent<Collider2D>();
        if (col != null) col.enabled = false;

        if (anim != null)
        {
            anim.SetFloat("Velocidad", 0f);
            anim.SetBool("EnSuelo", true);   
            anim.SetBool("Muerte", true); 
        }

        if (GameManager.Instance != null)
        {
            GameManager.Instance.MostrarPerdiste();
        }

        yield return new WaitForSeconds(tiempoMuerte);
    }
}