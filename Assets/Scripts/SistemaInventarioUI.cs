using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SistemaInventarioUI : MonoBehaviour
{
    public static SistemaInventarioUI Instancia { get; private set; }

    [Header("Referencias UI")]
    public GameObject panelInventario;
    public Transform gridContenedorPistas;
    public GameObject prefabPistaUI; // Usa el MISMO prefab que creamos para la Lógica

    // Estado interno
    private Pista pistaSeleccionada;
    private PistaUIElement uiElementSeleccionado;

    private void Awake()
    {
        if (Instancia != null && Instancia != this) Destroy(gameObject);
        else Instancia = this;
    }

    private void Start()
    {
        panelInventario.SetActive(false);
    }

    public void AbrirInventario()
    {
        panelInventario.SetActive(true);
        Time.timeScale = 0f; // Pausa el juego
        GenerarPistas();
    }

    public void CerrarInventario()
    {
        panelInventario.SetActive(false);
        Time.timeScale = 1f;
        LimpiarSeleccion();

        foreach (Transform child in gridContenedorPistas)
        {
            Destroy(child.gameObject);
        }
    }

    private void GenerarPistas()
    {
        List<Pista> inventario = OrganizadorPistas.Instance.GetPistas();

        foreach (Pista pista in inventario)
        {
            GameObject nuevoObjeto = Instantiate(prefabPistaUI, gridContenedorPistas);
            PistaUIElement elementoUI = nuevoObjeto.GetComponent<PistaUIElement>();

            elementoUI.Configurar(pista);
            Button boton = nuevoObjeto.GetComponent<Button>();
            boton.onClick.RemoveAllListeners();
            boton.onClick.AddListener(() => SeleccionarPista(elementoUI, pista));
        }
    }

    public void SeleccionarPista(PistaUIElement elementoUI, Pista pista)
    {

        if (uiElementSeleccionado != null) uiElementSeleccionado.SetSeleccionado(false);

        pistaSeleccionada = pista;
        uiElementSeleccionado = elementoUI;
        uiElementSeleccionado.SetSeleccionado(true);
    }

    private void LimpiarSeleccion()
    {
        if (uiElementSeleccionado != null) uiElementSeleccionado.SetSeleccionado(false);
        pistaSeleccionada = null;
        uiElementSeleccionado = null;
    }

    // --- PRESENTAR PRUEBA ---
    // Asigna esta función al botón "Presentar" en tu panel de Inventario
    public void ConfirmarPresentacion()
    {
        if (pistaSeleccionada == null)
        {
            Debug.Log("Selecciona una pista primero.");
            return;
        }

        SistemaInterrogatorio.Instancia.IntentarPresentarPista(pistaSeleccionada);

        CerrarInventario();
    }
}