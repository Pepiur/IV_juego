using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct TemaDialogo
{
    public string tituloTema; // Lo que lee el jugador en el botón (Ej: "Sobre el asesinato")
    public DialogoDataSO dialogoAsociado; // El diálogo lineal o el previo al interrogatorio
    public int progresoRequerido; // Cuándo aparece esta opción
    public Pista pistaRequerida; // Opcional: si requiere tener una pista para poder preguntar
}

public class DialogoCliente : MonoBehaviour
{
    [Header("Dialogo Inicial")]
    public DialogoDataSO saludo;
    [Header("Configuración de Diálogos")]
    public List<TemaDialogo> temasPosibles;
    public void HablarConNPC()
    {
        List<Pista> pistasActuales = OrganizadorPistas.Instance.GetPistas();
        int progresoActual = GameManager.Instancia.nivelProgresoHistoria;

        List<TemaDialogo> temasFiltrados = new List<TemaDialogo>();

        foreach (TemaDialogo tema in temasPosibles)
        {
            // Evaluamos si el jugador tiene el progreso necesario
            if (progresoActual >= tema.progresoRequerido)
            {
                // Evaluamos si requiere una pista y si la tenemos
                if (tema.pistaRequerida == null || pistasActuales.Contains(tema.pistaRequerida))
                {
                    temasFiltrados.Add(tema);
                }
            }
        }

        if (temasFiltrados.Count > 0)
        {
            SistemaOpcionesUI.Instancia.MostrarOpciones(temasFiltrados);
        }
        else
        {
            // Si no hay temas, un diálogo por defecto
            DialogoUI.Instance.IniciarDialogo("Edgeworth", "No parece que tenga nada útil que decirme ahora mismo.");
        }
    }
}