using UnityEngine;
namespace Patrones.State.Interfaces
{
    public interface IPlayer
    {
        public GameObject GetGameObject();
        public void SetState(IState state);
        public IState GetState();
        public void MoveTo(Transform target);
        public void GetPista();
    }
}
