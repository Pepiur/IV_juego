using UnityEngine;
namespace Patrones.State.Interfaces
{
    public interface IState
    {
        public void Caminar();
        public void InteractuarPista();
        public void InteractuarPersonaje();
        public void Logica();
        public void Enter();
        public void Exit();
        public void Update();
        public void FixedUpdate();
    }
}