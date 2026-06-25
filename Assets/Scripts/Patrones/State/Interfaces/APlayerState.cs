using UnityEngine;
namespace Patrones.State.Interfaces
{
    public abstract class APlayerState : IState
    {
        protected IPlayer player;

        public APlayerState(IPlayer player)
        {
            this.player = player;
        }
        public virtual void Enter() { }
        public virtual void Update() { }
        public virtual void FixedUpdate() { }
        public virtual void Exit() { }
    }
}
