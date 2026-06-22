using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SistemaOpcionesUI : MonoBehaviour
{
    public static SistemaOpcionesUI Instancia { get; private set; }

    [Header("UI del Menú")]
    public GameObject panelOpciones;
    public Transform contenedorBotones;
    public GameObject prefabBotonOpcion;
    public Button botonSalir;

    private void Awake()
    {
        if (Instancia != null && Instancia != this) Destroy(gameObject);
        else Instancia = this;
    }

    private void Start()
    {
        panelOpciones.SetActive(false);
        botonSalir.onClick.AddListener(CerrarMenuOpciones);
    }

    public void MostrarOpciones(List<TemaDialogo> temasDisponibles)
    {
        panelOpciones.SetActive(true);
        LimpiarBotones();

        foreach (TemaDialogo tema in temasDisponibles)
        {
            GameObject nuevoBoton = Instantiate(prefabBotonOpcion, contenedorBotones);
            nuevoBoton.GetComponentInChildren<TextMeshProUGUI>().text = tema.tituloTema;

            // Configuramos el clic del botón
            nuevoBoton.GetComponent<Button>().onClick.AddListener(() =>
            {
                CerrarMenuOpciones();
                LanzarTema(tema);
            });
        }
    }

    private void LanzarTema(TemaDialogo tema)
    {
        ContextoJugador contexto = new ContextoJugador(OrganizadorPistas.Instance.GetPistas(), GameManager.Instancia.nivelProgresoHistoria);
        tema.dialogoAsociado.EjecutarDialogo(contexto);
    }

    public void CerrarMenuOpciones()
    {
        panelOpciones.SetActive(false);
        LimpiarBotones();
    }

    private void LimpiarBotones()
    {
        foreach (Transform child in contenedorBotones)
        {
            Destroy(child.gameObject);
        }
    }
}