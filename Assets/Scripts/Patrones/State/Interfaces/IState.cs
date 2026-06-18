using UnityEngine;
namespace Patrones.State.Interfaces
{
    public interface IState
    {
        void Enter();        
        void Update();      
        void FixedUpdate();  
        void Exit();
    }
}