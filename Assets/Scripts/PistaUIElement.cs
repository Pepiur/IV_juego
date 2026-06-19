using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PistaUIElement : MonoBehaviour
{
    [Header("Referencias UI")]
    public TextMeshProUGUI textoTitulo;
    public TextMeshProUGUI textoDescripcion;
    public Image imagenIcono;

    [Header("Feedback Visual")]
    public Image marcoSeleccion; 

    private Pista pistaAsignada;

    public void Configurar(Pista pista)
    {
        pistaAsignada = pista;
        textoTitulo.text = pista.nombre;
        textoDescripcion.text = pista.descripcion;

        if (pista.icono != null) imagenIcono.sprite = pista.icono;
        SetSeleccionado(false);
    }
    public void AlHacerClic()
    {
        SistemaLogica.Instancia.SeleccionarPista(this, pistaAsignada);
    }

    public void SetSeleccionado(bool seleccionado)
    {
        if (marcoSeleccion != null)
        {
            marcoSeleccion.enabled = seleccionado;
        }
    }
}