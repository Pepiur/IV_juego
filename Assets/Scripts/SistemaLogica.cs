using UnityEngine;

public class SistemaLogica : MonoBehaviour
{
    public static SistemaLogica Instancia { get; private set; }

    [Header("Referencias de UI - Pantalla de Lógica")]
    [SerializeField] private GameObject panelLogica;

    private Pista pistaSeleccionada1;
    private Pista pistaSeleccionada2;

    private void Awake()
    {
        if (Instancia != null && Instancia != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instancia = this;
    }

    private void Start()
    {
        panelLogica.SetActive(false);
    }

    public void AbrirMenuLogica()
    {
        panelLogica.SetActive(true);
        // Aquí podrías pedirle las pistas al Organizador para mostrarlas en pantalla
        // List<Pista> pistasDisponibles = OrganizadorPistas.Instancia.GetPistas();
    }

    public void SeleccionarPistaParaCombinar(Pista pista)
    {
        if (pistaSeleccionada1 == null)
        {
            pistaSeleccionada1 = pista;
        }
        else if (pistaSeleccionada2 == null && pista != pistaSeleccionada1)
        {
            pistaSeleccionada2 = pista;
            IntentarCombinar();
        }
    }

    private void IntentarCombinar()
    {
        Debug.Log($"Intentando combinar: {pistaSeleccionada1.nombre} y {pistaSeleccionada2.nombre}");

        // Aquí irá la lógica para comprobar si la combinación es correcta (ej. un diccionario de combinaciones)

        pistaSeleccionada1 = null;
        pistaSeleccionada2 = null;
    }
}