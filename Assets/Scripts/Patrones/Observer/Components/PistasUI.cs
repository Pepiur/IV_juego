using System.Collections.Generic;
using UnityEngine;

public class PistasUI : MonoBehaviour, IPistaObserver
{
    

    private void Awake()
    {

    }
    void Start()
    {
        OrganizadorPistas.Instance.AddObserver(this);
    }

    public void ActualizarPistas(List<Pista> pistas)
    {
        ShowPistas(pistas);
    }

    public void ShowPistas(List<Pista> pistas)
    {
        Debug.Log("UI Actualizada. Pistas totales en UI: " + pistas.Count);
        // TODO: Aquí instanciarás los prefabs visuales de tu Sistema de Lógica
    }

    void OnDestroy()
    {
        if (OrganizadorPistas.Instance != null) OrganizadorPistas.Instance.RemoveObserver(this);
    }
}