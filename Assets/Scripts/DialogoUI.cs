using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class DialogoUI : MonoBehaviour
{
    public static DialogoUI Instance { get; private set; }

    [Header("Referencias de UI")]
    [SerializeField] private GameObject panelDialogo;
    [SerializeField] private TextMeshProUGUI textoNombre;
    [SerializeField] private TextMeshProUGUI textoDialogo;
    [SerializeField] private Button botonAvanzar;
    public float closeDialogo = 4.0f;

    private DialogoDataSO nodoActual;
    private bool estaHablando = false;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        panelDialogo.SetActive(false);
        if (botonAvanzar != null)
        {
            botonAvanzar.onClick.AddListener(IntentarAvanzarDialogo);
        }
    }

    public void CargarNodoDialogo(DialogoDataSO nodo)
    {
        panelDialogo.SetActive(true);
        estaHablando = true;
        nodoActual = nodo;

        ActualizarPantalla();
    }

    private void ActualizarPantalla()
    {
        if (nodoActual == null) return;

        textoNombre.text = nodoActual.personaje;
        textoDialogo.text = nodoActual.texto;
    }

    public void IntentarAvanzarDialogo()
    {
        if (!estaHablando) return;
        if (nodoActual.siguienteDialogo != null)
        {
            nodoActual = nodoActual.siguienteDialogo;
            ActualizarPantalla();
        }
        else if (nodoActual.interrogatorioParaLanzar != null)
        {
            panelDialogo.SetActive(true);
            SistemaInterrogatorio.Instancia.IniciarInterrogatorio(nodoActual.interrogatorioParaLanzar);
        }
        else if (nodoActual.disparaFinDeJuego)
        {
            GameManager.Instancia.NivelCompletado();
        }
        else
        {
            CerrarDialogo();
        }
    }

    public void IniciarDialogo(string nombreHablando, string contenido)
    {
        panelDialogo.SetActive(true);
        textoNombre.text = nombreHablando;
        textoDialogo.text = contenido;
    }



    public void CerrarDialogo()
    {

        panelDialogo.SetActive(false);
    }
}