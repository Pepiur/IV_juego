using UnityEngine;
namespace Patrones.State.Interfaces
{
    public interface IPlayer
    {
        Rigidbody2D GetRigidbody();
        Vector2 GetPosicionObjetivo();
        float GetVelocidad();
        LayerMask GetCapaPistas();
        LayerMask GetCapaNPCs();
        void SetPosicionObjetivo(Vector2 posicion);
        void CambiarEstado(IState nuevoEstado);
        IState GetStateAnterior();
        void setStateAnterior(IState nuevoEstado);
        IState GetState();
    }
}
