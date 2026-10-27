using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("UI - Paneles")]
    public GameObject panelGanaste;
    public GameObject panelPerdiste;

    [Header("Sonidos")]
    public AudioClip musicaFondo;
    public AudioClip sonidoGanar;
    public AudioClip sonidoPerder;

    // Reproductores internos
    private AudioSource reproductorMusica;
    private AudioSource reproductorEfectos;

    private bool juegoTerminado = false; 

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        Time.timeScale = 1f; 

        if (panelGanaste != null) panelGanaste.SetActive(false);
        if (panelPerdiste != null) panelPerdiste.SetActive(false); 

        // Configurar música de fondo
        reproductorMusica = gameObject.AddComponent<AudioSource>();
        reproductorMusica.clip = musicaFondo;
        reproductorMusica.loop = true; 
        reproductorMusica.volume = 0.4f; 
        if (musicaFondo != null) reproductorMusica.Play();

        // Configurar reproductor de efectos
        reproductorEfectos = gameObject.AddComponent<AudioSource>();
        reproductorEfectos.loop = false; 
    }

    public void MostrarGanaste()
    {
        if (juegoTerminado) return; 
        juegoTerminado = true;

        if (panelGanaste != null) panelGanaste.SetActive(true);

        // APAGAMOS LA MÚSICA DE FONDO
        if (reproductorMusica != null) reproductorMusica.Stop(); 
        
        // REPRODUCIMOS EL SONIDO DE VICTORIA
        if (sonidoGanar != null) reproductorEfectos.PlayOneShot(sonidoGanar);
        
        StartCoroutine(ReiniciarDespuesDeTiempo());
    }

    public void MostrarPerdiste()
    {
        if (juegoTerminado) return; 
        juegoTerminado = true;

        if (panelPerdiste != null) panelPerdiste.SetActive(true);

        //  APAGAMOS LA MÚSICA DE FONDO
        if (reproductorMusica != null) reproductorMusica.Stop();
        
        //  REPRODUCIMOS EL SONIDO DE DERROTA
        if (sonidoPerder != null) reproductorEfectos.PlayOneShot(sonidoPerder);
        
        StartCoroutine(ReiniciarDespuesDeTiempo());
    }

    private IEnumerator ReiniciarDespuesDeTiempo()
    {
        // CAMBIA ESTE NÚMERO SI QUIERES QUE DURE MÁS O MENOS EL REINICIO
        yield return new WaitForSeconds(4f); 
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}