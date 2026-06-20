using System.Collections.Generic;
using UnityEngine;

// Estructura para definir qué pistas se pueden combinar
[System.Serializable]
public struct CombinacionLogica
{
    public Pista pistaRequerida1;
    public Pista pistaRequerida2;
    public DialogoDataSO dialogoExito;
    public Pista pistaRecompensa;
}

public class SistemaLogica : MonoBehaviour
{
    public static SistemaLogica Instancia { get; private set; }

    [Header("Configuración UI")]
    public GameObject panelLogica;
    public Transform gridContenedorPistas;
    public GameObject prefabPistaUI;

    [Header("Reglas del Juego")]
    public List<CombinacionLogica> combinacionesValidas; 

    // Variables de estado
    private PistaUIElement uiSeleccion1;
    private PistaUIElement uiSeleccion2;
    private Pista pista1;
    private Pista pista2;

    private void Awake()
    {
        if (Instancia != null && Instancia != this) Destroy(gameObject);
        else Instancia = this;
    }

    private void Start()
    {
        panelLogica.SetActive(false);
    }

    // --- CONTROL DEL MENÚ ---

    public void AbrirMenuLogica()
    {
        panelLogica.SetActive(true);
        DialogoUI.Instance.CerrarDialogo();
        Time.timeScale = 0f; 
        GenerarPistasEnUI();
    }

    public void CerrarMenuLogica()
    {
        panelLogica.SetActive(false);
        Time.timeScale = 1f; 
        LimpiarSeleccion();

        foreach (Transform child in gridContenedorPistas)
        {
            Destroy(child.gameObject);
        }
    }



    private void GenerarPistasEnUI()
    {
        
        List<Pista> inventario = OrganizadorPistas.Instance.GetPistas();

        foreach (Pista pista in inventario)
        {
            GameObject nuevoObjeto = Instantiate(prefabPistaUI, gridContenedorPistas);
            PistaUIElement elementoUI = nuevoObjeto.GetComponent<PistaUIElement>();
            elementoUI.Configurar(pista);
        }
    }



    public void SeleccionarPista(PistaUIElement uiElement, Pista pista)
    {

        if (pista1 == pista)
        {
            uiSeleccion1.SetSeleccionado(false);
            pista1 = null; uiSeleccion1 = null;
            return;
        }
        if (pista2 == pista)
        {
            uiSeleccion2.SetSeleccionado(false);
            pista2 = null; uiSeleccion2 = null;
            return;
        }


        if (pista1 == null)
        {
            pista1 = pista;
            uiSeleccion1 = uiElement;
            uiSeleccion1.SetSeleccionado(true);
        }

        else if (pista2 == null)
        {
            pista2 = pista;
            uiSeleccion2 = uiElement;
            uiSeleccion2.SetSeleccionado(true);
        }
    }

    private void LimpiarSeleccion()
    {
        if (uiSeleccion1 != null) uiSeleccion1.SetSeleccionado(false);
        if (uiSeleccion2 != null) uiSeleccion2.SetSeleccionado(false);
        pista1 = null; pista2 = null;
        uiSeleccion1 = null; uiSeleccion2 = null;
    }


    public void IntentarCombinar()
    {
        if (pista1 == null || pista2 == null)
        {
            Debug.Log("Necesitas seleccionar dos pistas primero.");
            return;
        }

        bool exito = false;

        foreach (CombinacionLogica combo in combinacionesValidas)
        {
            if ((pista1 == combo.pistaRequerida1 && pista2 == combo.pistaRequerida2) ||
                (pista1 == combo.pistaRequerida2 && pista2 == combo.pistaRequerida1))
            {
                CerrarMenuLogica();
                if (combo.pistaRecompensa != null)
                {
                    OrganizadorPistas.Instance.CollectPista(combo.pistaRecompensa);
                }
                if (combo.dialogoExito != null)
                {
                    ContextoJugador contexto = new ContextoJugador(OrganizadorPistas.Instance.GetPistas(), 1); //ESE UNO HABRIA QUE CAMBIARLO POR ALGUNA VARIABLE QUE AUMENTE O ALGO ASI
                    combo.dialogoExito.EjecutarDialogo(contexto);
                }
                exito = true;

                // TODO: Aquí podrías reproducir la animación de "¡EUREKA!" de Edgeworth
                // y salir del menú o añadir una nueva pista deductiva al inventario.

                CerrarMenuLogica();
                break;
            }
        }

        if (!exito)
        {
            Debug.Log("Estas pistas no parecen tener relación... Pierdes salud/puntos.");
            LimpiarSeleccion();
            // TODO: Reproducir sonido de error o restar vida
        }
    }
}