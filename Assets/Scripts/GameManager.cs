using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instancia { get; private set; }

    [Header("Estado del Jugador")]
    public int vidaMaxima = 6;
    private int vidaActual;

    [Header("Historia")]
    public int nivelProgresoHistoria = 0;

    public bool estaInterrogando = false;

    [Header("Transiciones de Escena")]
    // Esta variable guardará el ID del lugar donde el jugador debe aparecer
    public string idProximoSpawn = "";

    public bool puedeMoverse = true;

    [Header("UI de Modos (Diálogo/Interrogatorio)")]
    public GameObject panelModoOscuro;
    public TextMeshProUGUI textoModo;

    public GameObject canvasGlobal;

    private void Awake()
    {
        if (Instancia != null && Instancia != this) Destroy(gameObject);
        else Instancia = this;

        vidaActual = vidaMaxima;
    }

    private void Start()
    {
        // Actualizamos la UI al empezar el juego
        SistemaVidaUI.Instancia.ActualizarVidas(vidaActual, vidaMaxima);
        if (panelModoOscuro != null) panelModoOscuro.SetActive(false);
        puedeMoverse = true;
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += AlCargarEscena;
    }


    private void OnDisable()
    {
        SceneManager.sceneLoaded -= AlCargarEscena;
    }

    private void AlCargarEscena(Scene escena, LoadSceneMode modo)
    {
        // Comparamos el nombre de la escena actual
        if (escena.name == "Victoria" || escena.name == "Derrota" || escena.name == "MenuPrincipal")
        {
            // Si estamos en pantallas de fin o menú, apagamos la interfaz de juego
            if (canvasGlobal != null)
            {
                canvasGlobal.SetActive(false);
            }
        }
        else
        {
            if (canvasGlobal != null)
            {
                canvasGlobal.SetActive(true);
            }
        }
    }

    public void ActivarModoNarrativo(string tipoModo)
    {
        puedeMoverse = false;

        if (panelModoOscuro != null && textoModo != null)
        {
            textoModo.text = tipoModo;
            panelModoOscuro.SetActive(true);
        }
    }

    public void DesactivarModoNarrativo()
    {
        puedeMoverse = true;

        if (panelModoOscuro != null)
        {
            panelModoOscuro.SetActive(false);
        }
    }

    public void AvanzarHistoria(int cantidad)
    {
        nivelProgresoHistoria += cantidad;
        Debug.Log("La historia ha avanzado al nivel: " + nivelProgresoHistoria);
    }

    public void RecibirDano(int dano = 1)
    {
        vidaActual -= dano;

        SistemaVidaUI.Instancia.ActualizarVidas(vidaActual, vidaMaxima);

        Debug.Log($"¡Protesta denegada! Vida restante: {vidaActual}");

        if (vidaActual <= 0) Derrota();
    }

    private void Derrota()
    {
        SceneManager.LoadScene(5);
    }

    public void NivelCompletado()
    {
        Debug.Log("¡CASO RESUELTO! El jugador ha completado el nivel.");
        Time.timeScale = 0f;
        esperar();
        SceneManager.LoadScene(4);
    }

    IEnumerator esperar()
    {
        yield return new WaitForSeconds(5.0f);
        StopAllCoroutines();
    }
}