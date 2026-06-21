using UnityEngine;
using TMPro;

public class SistemaInterrogatorio : MonoBehaviour
{
    public static SistemaInterrogatorio Instancia { get; private set; }

    [Header("UI del Interrogatorio")]
    public GameObject panelInterrogatorio;
    public TextMeshProUGUI textoPersonaje;
    public TextMeshProUGUI textoDeclaracion;

    private InterrogatorioSO interrogatorioActual;
    private int indiceFraseActual = 0;

    private void Awake()
    {
        if (Instancia != null && Instancia != this) Destroy(gameObject);
        else Instancia = this;
    }

    private void Start()
    {
        panelInterrogatorio.SetActive(false);
    }

    public void IniciarInterrogatorio(InterrogatorioSO nuevoInterrogatorio)
    {
        interrogatorioActual = nuevoInterrogatorio;
        indiceFraseActual = 0;
        panelInterrogatorio.SetActive(true);
        ActualizarPantalla();
    }

    // --- NAVEGACIÓN (Asignar a botones de UI) ---

    public void AvanzarFrase()
    {
        if (indiceFraseActual < interrogatorioActual.frases.Length - 1)
        {
            indiceFraseActual++;
            ActualizarPantalla();
        }
    }

    public void RetrocederFrase()
    {
        if (indiceFraseActual > 0)
        {
            indiceFraseActual--;
            ActualizarPantalla();
        }
    }

    private void ActualizarPantalla()
    {
        textoPersonaje.text = interrogatorioActual.personaje;
        textoDeclaracion.text = interrogatorioActual.frases[indiceFraseActual];
    }

    // --- PRESENTAR PISTA ---

    // Este método se llama cuando el jugador selecciona una pista de su inventario
    // e intenta usarla contra la frase actual.
    public void IntentarPresentarPista(Pista pistaPresentada)
    {
        // ¿Es la pista correcta EN la frase correcta?
        if (pistaPresentada == interrogatorioActual.pistaRequerida &&
            indiceFraseActual == interrogatorioActual.indiceFraseDebil)
        {
            ExitoEnInterrogatorio();
        }
        else
        {
            FalloEnInterrogatorio();
        }
    }

    private void ExitoEnInterrogatorio()
    {
        Debug.Log("¡OBJECTION! Contradicción encontrada.");

        panelInterrogatorio.SetActive(false); // Ocultamos el modo interrogatorio

        // 1. Avanzamos la historia
        GameManager.Instancia.AvanzarHistoria(interrogatorioActual.progresoOtorgado);

        // 2. Disparamos el diálogo de victoria (Flyweight)
        if (interrogatorioActual.dialogoExito != null)
        {
            ContextoJugador contexto = new ContextoJugador(OrganizadorPistas.Instance.GetPistas(), GameManager.Instancia.nivelProgresoHistoria);
            interrogatorioActual.dialogoExito.EjecutarDialogo(contexto);
        }
    }

    private void FalloEnInterrogatorio()
    {
        // Aplicamos daño. El GameManager se encarga del Game Over si llega a 0.
        GameManager.Instancia.RecibirDano(1);

        // TODO: Puedes disparar un diálogo temporal del juez o el rival burlándose
        Debug.Log("Esa pista no prueba nada en este momento.");
    }
}