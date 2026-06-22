using UnityEngine;

[CreateAssetMenu(fileName = "Dialogo", menuName = "Juego/Dialogo")]
public class DialogoDataSO : ScriptableObject, IDialogoFlyweight
{
    [Header("Estado Intrínseco (Datos Compartidos)")]
    public string idDialogo;
    public string personaje;
    [TextArea(3, 5)] public string texto;

    [Header("Encadenamiento")]
    public DialogoDataSO siguienteDialogo;

    [Header("Condiciones (Estado Intrínseco)")]
    public Pista pistaRequerida; // Si es null, el diálogo siempre está disponible
    public int nivelProgresoRequerido = 0;

    [Header("Interrogatorio")]
    // Si asignas un interrogatorio aquí, al terminar de leer este diálogo, comenzará automáticamente
    public InterrogatorioSO interrogatorioParaLanzar;
    public void EjecutarDialogo(ContextoJugador contexto)
    {
        if (contexto.progresoHistoria < nivelProgresoRequerido)
        {
            DialogoUI.Instance.IniciarDialogo(personaje, "Aún no tengo nada de qué hablar contigo.");
            return;
        }

        if (pistaRequerida != null && !contexto.pistasEnInventario.Contains(pistaRequerida))
        {
            DialogoUI.Instance.IniciarDialogo("Edgeworth", "Parece que me falta información vital para presionar sobre este tema...");
            return;
        }
        DialogoUI.Instance.CargarNodoDialogo(this);
    }
}