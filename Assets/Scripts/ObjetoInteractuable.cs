using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Collider2D))]
public class ObjetoInteractuable : MonoBehaviour
{
    [Header("Información del Objeto")]
    public string nombreObjeto = "";

    public GameObject objetoBrillo;


    private void Start()
    {
        // Nos aseguramos de que el brillo empiece apagado
        if (objetoBrillo != null) objetoBrillo.SetActive(false);

        // Nos suscribimos al evento del Sistema de Resaltado
        if (SistemaTooltip.Instancia != null)
        {
            SistemaTooltip.Instancia.OnResaltarObjetos += AlternarBrillo;
        }
    }

    private void OnDestroy()
    {

        if (SistemaTooltip.Instancia != null)
        {
            SistemaTooltip.Instancia.OnResaltarObjetos -= AlternarBrillo;
        }
    }

    private void AlternarBrillo(bool estado)
    {
        if (objetoBrillo != null)
        {
            objetoBrillo.SetActive(estado);
        }
    }
    private void OnMouseEnter()
    {
        if (Time.timeScale > 0f && !EventSystem.current.IsPointerOverGameObject())
        {
            SistemaTooltip.Instancia.MostrarTooltip(nombreObjeto);
        }
    }

    private void OnMouseExit()
    {
        SistemaTooltip.Instancia.OcultarTooltip();
    }

    private void OnMouseDown()
    {
        SistemaTooltip.Instancia.OcultarTooltip();
    }
}