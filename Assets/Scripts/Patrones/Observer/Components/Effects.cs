using System.Collections.Generic;
using UnityEngine;

public class Effects : MonoBehaviour, IPistaObserver
{
    [SerializeField] private OrganizadorPistas organizador;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip sonidoRecoger;

    private void Awake()
    {
        if (organizador == null)
        {
            organizador = OrganizadorPistas.Instance;
        }
    }
    void Start()
    {
        organizador.AddObserver(this);
    }

    public void ActualizarPistas(List<Pista> pistas)
    {
        PlayPistaPick();
    }

    public void PlayPistaPick()
    {
        Debug.Log("Efecto de sonido de pista reproducido.");
        if (audioSource != null && sonidoRecoger != null)
        {
            audioSource.PlayOneShot(sonidoRecoger);
        }
    }

    void OnDestroy()
    {
        if (organizador != null) organizador.RemoveObserver(this);
    }
}