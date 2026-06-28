using System.Collections.Generic;
using UnityEngine;

public class OrganizadorPistas : MonoBehaviour
{
    private List<IPistaObserver> observerCollection = new List<IPistaObserver>();
    public List<Pista> pistas = new List<Pista>();


    //Patron singleton
    public static OrganizadorPistas Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
    }
    public void AddObserver(IPistaObserver observer)
    {
        if (!observerCollection.Contains(observer))
        {
            observerCollection.Add(observer);
        }
    }

    public void RemoveObserver(IPistaObserver observer)
    {
        if (observerCollection.Contains(observer))
        {
            observerCollection.Remove(observer);
        }
    }

    public void NotifyObserver()
    {

        foreach (IPistaObserver observer in observerCollection)
        {
            observer.ActualizarPistas(pistas);
        }
    }

    public void CollectPista(Pista nuevaPista)
    {
        if (!pistas.Contains(nuevaPista))
        {
            pistas.Add(nuevaPista);
            Debug.Log($"Pista recogida: {nuevaPista.nombre}");
            NotifyObserver();
            GameManager.Instancia.AvanzarHistoria(1);
        }
    }
    public List<Pista> GetPistas() => pistas;
}