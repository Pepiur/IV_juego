using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instancia { get; private set; }

    [Header("Estado del Jugador")]
    public int vidaMaxima = 5;
    private int vidaActual;

    [Header("Historia")]
    public int nivelProgresoHistoria = 0;

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
    }

    public void AvanzarHistoria(int cantidad)
    {
        nivelProgresoHistoria += cantidad;
        Debug.Log("La historia ha avanzado al nivel: " + nivelProgresoHistoria);
    }

    public void RecibirDano(int dano = 1)
    {
        vidaActual -= dano;

        // Actualizamos la UI inmediatamente después del daño
        SistemaVidaUI.Instancia.ActualizarVidas(vidaActual, vidaMaxima);

        Debug.Log($"¡Protesta denegada! Vida restante: {vidaActual}");

        if (vidaActual <= 0) FinDeJuego();
    }

    private void FinDeJuego()
    {
        Debug.Log("GAME OVER: Has perdido toda tu credibilidad.");
        // TODO: Mostrar pantalla de Game Over y recargar la escena o ir al menú principal
    }
}