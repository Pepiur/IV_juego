using UnityEngine;
using Patrones.State.Interfaces;
using IState = Patrones.State.Interfaces.IState;
using UnityEngine.Rendering.Universal;
using NUnit.Framework.Constraints;
public class PlayerController : MonoBehaviour, IPlayer
{
    public float velocidad = 4f;
    public LayerMask capaPistas;
    public LayerMask capaNPCs;

    private Rigidbody2D rb;
    private Vector2 posicionObjetivo;

    private IState estadoActual;
    private IState estadoAnterior;
    void Start()
    {
        posicionObjetivo = transform.position;
        rb = GetComponent<Rigidbody2D>();

        CambiarEstado(new Idle(this));
    }

    void Update()
    {
        estadoActual?.Update();
    }


    void FixedUpdate()
    {
        estadoActual?.FixedUpdate();
    }

    public void CambiarEstado(IState nuevoEstado)
    {
        estadoActual?.Exit();
        estadoAnterior = estadoActual;
        estadoActual = nuevoEstado;
        estadoActual.Enter();

        //Debug.Log("Cambiando a estado: " + nuevoEstado.GetType().Name);
    }

    public Rigidbody2D GetRigidbody() => this.rb;
    public Vector2 GetPosicionObjetivo() => this.posicionObjetivo;
    public void SetPosicionObjetivo(Vector2 posicion) => this.posicionObjetivo = posicion;
    public float GetVelocidad() => this.velocidad;

    public LayerMask GetCapaPistas() => this.capaPistas;
    public LayerMask GetCapaNPCs() => this.capaNPCs;


    public IState GetStateAnterior()
    {
        return this.estadoAnterior;
    }

    public void setStateAnterior(IState nuevoEstado)
    {
        this.estadoAnterior = nuevoEstado;
    }

    public IState GetState()
    {
        return this.estadoActual;
    }
}
